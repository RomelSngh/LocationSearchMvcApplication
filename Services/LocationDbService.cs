using AutoMapper;
using LocationSearchApiMVCWithUsers.Data;
using LocationSearchApplicationAPI.Models;
using LocationSearchApplicationAPI.Models.FourSquare;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Venue = LocationSearchApplicationAPI.Models.Venue;

namespace LocationSearchApiMVCWithUsers.Services
{
    public class LocationDbService : ILocationDbService
    {
        //DI Vars 
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        List<LocationImage> MyLocationImages = new List<LocationImage>();

        public LocationDbService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string GetVenueFromVenueId(String VenueId)
        {
            var venue = _context.Venues.FirstOrDefault(v => v.Venueid == VenueId);
            if (venue != null)
            {
                return venue.Name;
            }
            else
            {
                return null;
            }
        }

        public Venue GetVenueObjectFromVenueId(String VenueId)
        {
            var venue = _context.Venues.FirstOrDefault(v => v.Venueid == VenueId);
            if (venue != null)
            {
                return venue;
            }
            else
            {
                return null;
            }
        }

        public LocationImage GetDbImageById(string Id)
        {
            return _context.LocationImages.ToList().First(i => i.ImageId == Id);
        }

        public void SaveLocationImagestoDb(List<LocationImage> myLocationImages)
        {
            foreach (LocationImage li in myLocationImages)
            {
                if (_context.LocationImages.Where(l => l.ImageId == li.ImageId).Count() == 0)
                {
                    _context.LocationImages.Add(li);
                }
            }
            _context.SaveChanges();
        }

        public async Task<List<Venue>> GetSavedVenues(string place, string placeType, string userId)
        {
            if (!String.IsNullOrEmpty(place) && !String.IsNullOrEmpty(placeType))
            {
                var savedVenues = _context.Venues.Where(v => v.UserId == Guid.Parse(userId)
                                                        && v.PlaceSearch == place
                                                        && v.PlaceSearchCategory == placeType);
                return await Task.FromResult(savedVenues.ToList());
            }
            else if (!String.IsNullOrEmpty(place))
            {
                var savedVenues = _context.Venues.Where(v => v.UserId == Guid.Parse(userId)
                                                        && v.PlaceSearch == place);
                return await Task.FromResult(savedVenues.ToList());
            }
            else
            {
                var savedVenues = _context.Venues.Where(v => v.UserId == Guid.Parse(userId));
                return await Task.FromResult(savedVenues.ToList());
            }
        }

        public void SaveVenuesToDatabase(List<Venue> VmVenues, string userId, string place = "", string placeType = "")
        {
            foreach (Venue ven in VmVenues)
            {
                if (_context.Venues.Where(v => v.Venueid == ven.Venueid && v.UserId == Guid.Parse(userId)).Count() == 0)
                {
                    ven.UserId = Guid.Parse(userId);
                    ven.PlaceSearch = place;
                    ven.PlaceSearchCategory = placeType;
                    _context.Venues.Add(ven);
                } // If VenueId already exists , then dont add it again. 
                _context.SaveChanges();
            }

        }

        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "ImageId" })]
        public ActionResult GetImage(string ImageId)
        {
            MyLocationImages = _context.LocationImages.ToList();
            if (MyLocationImages != null)
            {
                var image = MyLocationImages.Find(li => li.ImageId == ImageId);
                if (image != null)
                    if (image.Image != null)
                    {
                        byte[] byteArray = image.Image;
                        return new FileContentResult(byteArray, "image/png");
                    }
            }
            return null;
        }

        public async Task<List<LocationImageVM>> GetLocationImagesAsync(string venueId)
        {
            var locationImages = _context.LocationImages.Where(li => li.VenueId == venueId).ToList();
            var locationImagesVms = locationImages.Select(li => _mapper.Map<LocationImageVM>(li)).ToList();
            return await Task.FromResult(locationImagesVms);
         }
    }
}
