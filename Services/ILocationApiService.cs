using LocationSearchApplicationAPI.Models;
using LocationSearchApplicationAPI.Models.Flickr.PhotoDetails;
using Microsoft.AspNetCore.Mvc;

namespace LocationSearchApiMVCWithUsers.Services
{
    public interface ILocationApiService
    {
        ActionResult GetImageFromByte(string ImageData);
        Task<List<LocationImageVM>> GetLocationImagesAsync(string VenueId, double? lat, double? lng);
        Task<Photo> GetPhotoDetailObject(string photoId);
        Task<List<Venue>> GetVenues(string place, string placeType,string userId = "");
        void RefreshClient(string url);
    }
}