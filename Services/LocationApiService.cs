using AutoMapper;
using LocationSearchApplicationAPI.Helper;
using LocationSearchApplicationAPI.Models;
using LocationSearchApplicationAPI.Models.Flickr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LocationSearchApiMVCWithUsers.Services
{
    public class LocationApiService : ILocationApiService
    {
        HttpClient Client;

        string HostUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["locationSearchAPIServiceUrl"];
        string Url = "";
        string DetailsUrl = "";
        string PhotoUrl = "";

        private readonly IMapper _mapper;
        private readonly ILocationDbService _locationDbService;
        public LocationApiService(IMapper mapper, ILocationDbService locationDbService)
        {
            Url = HostUrl + "/Locations/GetRecommendVenues?searchLocation=pinetown&venueType=cars";
            DetailsUrl = HostUrl + "/Locations/GetVenueImages?lat={0}&lng={1}";
            PhotoUrl = HostUrl + "/Locations/getPhotoDetails?photoId={0}";

            Client = new HttpClient();

            RefreshClient(Url);
            _mapper = mapper;
            _locationDbService = locationDbService;
        }

        public void RefreshClient(string url)
        {
            Client.BaseAddress = new Uri(url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Venue>> GetVenues(string place, string placeType,string userId="")
        {
            if (!String.IsNullOrEmpty(place) && !String.IsNullOrEmpty(placeType))
            {
                string hostUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["locationSearchAPIServiceUrl"];

                Url = String.Format("{0}/Locations/GetRecommendVenues?searchLocation={1}&venueType={2}", hostUrl, place, placeType);
            }

            HttpResponseMessage responseMessage = await Client.GetAsync(Url);

            //place or placetype wasnt parsed in so the default valus are being used
            if (String.IsNullOrEmpty(place))
            {
                place = responseMessage.RequestMessage.GetQueryNameValuePairs().First(kvp => kvp.Key == "searchLocation").Value;
                placeType = responseMessage.RequestMessage.GetQueryNameValuePairs().First(kvp => kvp.Key == "venueType").Value;
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                List<LocationSearchApplicationAPI.Models.FourSquare.Venue> venues
                    = JsonConvert.DeserializeObject<List<LocationSearchApplicationAPI.Models.FourSquare.Venue>>(responseData);

                List<LocationSearchApplicationAPI.Models.Venue> vmVenues = new List<LocationSearchApplicationAPI.Models.Venue>();

                foreach (var venue in venues)
                {
                    var vmVenue = _mapper.Map<LocationSearchApplicationAPI.Models.Venue>(venue);
                    vmVenues.Add(vmVenue);
                }

                _locationDbService.SaveVenuesToDatabase(vmVenues,userId, place, placeType);
                return await Task.FromResult(vmVenues);
            }
            return null;
        }
        public async Task<List<LocationImageVM>> GetLocationImagesAsync(string VenueId, Double? lat, Double? lng)
        {
            int countimageResults = 0;

            LocationImage li;
            //to return to UI 
            List<LocationImageVM> locationImagesVms = new List<LocationImageVM>();
            //to save to db 
            List<LocationImage> locationImages = new List<LocationImage>();

            DetailsUrl = String.Format(DetailsUrl, lat, lng);
            RefreshClient(DetailsUrl);
            HttpResponseMessage responseMessage = await Client.GetAsync(DetailsUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                List<LocationSearchApplicationAPI.Models.Flickr.Photos.Photo> Photos = JsonConvert.DeserializeObject<List<LocationSearchApplicationAPI.Models.Flickr.Photos.Photo>>(responseData);

                foreach (LocationSearchApplicationAPI.Models.Flickr.Photos.Photo photo in Photos)
                {
                    li = new LocationImage();
                    li.VenueId = VenueId;
                    li.ImageId = photo.Id;
                    li.PhotoTitle = photo.Title;
                    LocationSearchApplicationAPI.Models.Flickr.PhotoDetails.Photo pDetail = await GetPhotoDetailObject(photo.Id);
                    string url = ImageHelper.GetFlickrUrl(pDetail);
                    li.Image = ImageHelper.GetWebImageFromDownloadUrl(url);

                    if (!String.IsNullOrEmpty(url))
                    {
                        var liVm = _mapper.Map<LocationImageVM>(li);
                        locationImages.Add(li);
                        locationImagesVms.Add(liVm);

                        countimageResults++;
                        if (countimageResults == 5)
                        {
                            _locationDbService.SaveLocationImagestoDb(locationImages);
                            return await Task.FromResult(locationImagesVms.ToList());
                        }
                    }
                }

            }
            return await Task.FromResult(locationImagesVms.ToList());
        }


        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "ImageData" })]
        public ActionResult GetImageFromByte(string ImageData)
        {
            if (ImageData != null)
            {
                byte[] array = Convert.FromBase64String(ImageData);

                return new FileContentResult(array, "image/png");
            }
            return null;
        }

       

        public async Task<LocationSearchApplicationAPI.Models.Flickr.PhotoDetails.Photo> GetPhotoDetailObject(string photoId)
        {
            HttpResponseMessage responseMessage = await Client.GetAsync(String.Format(PhotoUrl, photoId));
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                LocationSearchApplicationAPI.Models.Flickr.PhotoDetails.Photo Photo = JsonConvert.DeserializeObject<LocationSearchApplicationAPI.Models.Flickr.PhotoDetails.Photo>(responseData);

                return Photo;
            }
            else return null;
        }

    }
}
