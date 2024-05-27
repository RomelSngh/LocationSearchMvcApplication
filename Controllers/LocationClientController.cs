using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LocationSearchApplicationAPI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using LocationSearchApiMVCWithUsers.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Drawing.Text;
using System.Security.AccessControl;
using LocationSearchApiMVCWithUsers.Services;

namespace LocationSearchApplicationAPI.Controllers
{
    public class LocationClientController : Controller
    {
        private readonly ILocationApiService _locationApiService;
        private readonly ILocationDbService _locationDbService; 

        public LocationClientController(ApplicationDbContext context, IMapper mapper, ILocationDbService locationDbService, ILocationApiService locationApiService)
        {
            _locationApiService = locationApiService;
            _locationDbService = locationDbService;
        }

        // GET: LocationClient
        public async Task<ActionResult> Index(string place, string placetype,bool isSavedData = false)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!isSavedData)
            {
                var vmVenues = await _locationApiService.GetVenues(place, placetype,userId);
                return View(vmVenues);                
            }
            else {
                var savedVenues = await _locationDbService.GetSavedVenues(place,placetype,userId);
                return View(savedVenues);
            }
        }

    }
}