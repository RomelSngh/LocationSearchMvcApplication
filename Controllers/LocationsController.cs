using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using LocationSearchApplicationAPI.Models.FourSquare;
using LocationSearchApplicationAPI.Models.Flickr;
using System.Web.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace LocationSearchApplicationAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {

        [Microsoft.AspNetCore.Mvc.HttpGet("GetRecommendVenues")]
        public List<Venue> GetRecommendVenues([FromQuery(Name = "searchLocation")] string searchLocation, [FromQuery(Name = "venueType")] string venueType)
        {
            string clientId = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["clientid"];
            string secretKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["secretKey"];
      
            string URI = "https://api.foursquare.com/v2/venues/search";
            RootObject result = new RootObject();

            using (WebClient wc = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("near", searchLocation);
                reqparm.Add("venuePhotos", "1");
                reqparm.Add("client_id", clientId);
                reqparm.Add("client_secret", secretKey);
                reqparm.Add("v", "20231010");                                
                reqparm.Add("query", venueType);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12;

                byte[] responsebytes = wc.UploadValues(URI, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                result = JsonConvert.DeserializeObject<RootObject>(responsebody);
            }

            return result.Response.Venues;

        }

        [Microsoft.AspNetCore.Mvc.HttpGet("GetVenueImages")]
        public List<Models.Flickr.Photos.Photo> GetVenueImages([FromQuery]Double? lat,[FromQuery]Double? lng) 
        {
            string apikey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["apikey"];

            string URI = "https://api.flickr.com/services/rest";            

            //first get the Flickr PlaceId using Api 
            //update 2024-05-24 changed Places Api call to Photo Api call i.e Places Api not returning 0 place objects 
            Models.Flickr.Photos.RootObject result = new Models.Flickr.Photos.RootObject();
            
            using (WebClient wc = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                //reqparm.Add("method", "flickr.places.findByLatLon");
                reqparm.Add("method", "flickr.photos.search");
                reqparm.Add("api_key", apikey);
                reqparm.Add("lat", lat.ToString());
                reqparm.Add("lon", lng.ToString());
                reqparm.Add("accuracy", "16");
                reqparm.Add("format", "json");
                reqparm.Add("nojsoncallback", "1");
                reqparm.Add("privacy_filter", "1");
                
                byte[] responsebytes = wc.UploadValues(URI, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                result = JsonConvert.DeserializeObject<Models.Flickr.Photos.RootObject>(responsebody);
            }
            
            //get the Flickr PlaceID here from result 
            //string placeId = result.places.place[0].place_id;

            return result.Photos.Photo;
        }
        public List<Models.Flickr.Photos.Photo> GetVenueImages(string venueSearch = "", string PlaceId = "")
        {
            string apikey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["apikey"];
            string URI = "https://api.flickr.com/services/rest";

            Models.Flickr.Photos.RootObject result = new Models.Flickr.Photos.RootObject();

            using (WebClient wc = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("method", "flickr.photos.search");
                reqparm.Add("api_key", apikey);
                if (!String.IsNullOrEmpty(venueSearch))
                {
                    reqparm.Add("text", venueSearch);
                }
                if (!String.IsNullOrEmpty(PlaceId))
                {
                    reqparm.Add("place_id", PlaceId);    
                }
                reqparm.Add("format", "json");
                reqparm.Add("nojsoncallback", "1");
                
                byte[] responsebytes = wc.UploadValues(URI, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                result = JsonConvert.DeserializeObject<Models.Flickr.Photos.RootObject>(responsebody);
            }

            return result.Photos.Photo;
                  
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("getPhotoDetails")]
        public Models.Flickr.PhotoDetails.Photo GetPhotoDetails([FromQuery]string photoId)
        {
            string apikey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["apikey"];

            string URI = "https://api.flickr.com/services/rest";
            LocationSearchApplicationAPI.Models.Flickr.PhotoDetails.RootObject result = new Models.Flickr.PhotoDetails.RootObject();

            using (WebClient wc = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("method", "flickr.photos.getInfo");
                reqparm.Add("api_key", apikey);
                reqparm.Add("photo_id", photoId);
                reqparm.Add("format", "json");
                reqparm.Add("nojsoncallback", "1");

                byte[] responsebytes = wc.UploadValues(URI, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
                try
                { 
                    result = JsonConvert.DeserializeObject<Models.Flickr.PhotoDetails.RootObject>(responsebody);
                }
                catch(Exception ex )
                {
                   return null;
                }
            }

            return result.Photo;
        }
        
    }
}
