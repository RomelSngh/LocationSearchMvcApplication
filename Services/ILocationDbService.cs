using LocationSearchApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationSearchApiMVCWithUsers.Services
{
    public interface ILocationDbService
    {
        LocationImage GetDbImageById(string Id);
        ActionResult GetImage(string ImageId);
        Task<List<LocationImageVM>> GetLocationImagesAsync(string venueId);
        Task<List<Venue>> GetSavedVenues(string place, string placeType, string userId);
        string GetVenueFromVenueId(string VenueId);
        Venue GetVenueObjectFromVenueId(string VenueId);
        void SaveLocationImagestoDb(List<LocationImage> myLocationImages);
        void SaveVenuesToDatabase(List<Venue> VmVenues, string userId, string place = "", string placeType = "");
    }
}