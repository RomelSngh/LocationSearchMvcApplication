using System.Data;

using LocationSearchApplicationAPI.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LocationSearchApplicationAPI.Helper;
using Microsoft.AspNetCore.Html;
using LocationSearchApiMVCWithUsers.Data;
using AutoMapper;
using LocationSearchApplicationAPI.Models.FourSquare;
using System.Security.Claims;
using LocationSearchApiMVCWithUsers.Services;

namespace LocationSearchApplicationAPI.Controllers
{
    public class LocationImagesController : Controller
    {
        //DI Vars
        private readonly ILocationApiService _locationApiService;
        private readonly ILocationDbService _locationDbService;
        public LocationImagesController(ILocationApiService locationApiService,ILocationDbService locationDbService)
        {
            _locationApiService = locationApiService;
            _locationDbService = locationDbService;
        }
    
        public async Task<ActionResult> Index(string venueId, Double lat,Double lng)
        {            
            LocationImage li;
            //to return to UI 
            List<LocationImageVM> locationImagesVms = new List<LocationImageVM>();
            //to save to db 
            List<LocationImage> locationImages = new List<LocationImage>();

            if (lat != 0 && lng != 0)
            {
                locationImagesVms =   await _locationApiService.GetLocationImagesAsync(venueId, lat, lng);
                return View(locationImagesVms);
            }
            else
            {              
                locationImagesVms =await _locationDbService.GetLocationImagesAsync(venueId);
                var venue =  _locationDbService.GetVenueObjectFromVenueId(venueId);
                // This would mean the user hasnt specifically clicked on the view details link to search images for a Venue
                // Hence there are no related images for the venue. So search again 
                if (locationImagesVms.Count == 0)
                {
                    locationImagesVms = await _locationApiService.GetLocationImagesAsync(venueId,venue.Latitude,venue.Longitude);
                }
                return View(locationImagesVms);
            }
            return View("");
        }


        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "ImageId" })]
        public ActionResult GetImage(string ImageId)
        {
            var myLocationImages = _locationDbService.GetDbImageById(ImageId);

                var image = myLocationImages;
                if (image != null)
                    if (image.Image != null)
                    {
                        byte[] byteArray = image.Image;
                        return new FileContentResult(byteArray, "image/png");
                    }
            return null;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}