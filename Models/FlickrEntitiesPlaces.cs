using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationSearchApplicationAPI.Models.Flickr.Places
{
    //places
    public class Place
    {
        public string Place_id { get; set; }
        public string Woeid { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Place_url { get; set; }
        public string Place_type { get; set; }
        public string Place_type_id { get; set; }
        public string Timezone { get; set; }
        public string Name { get; set; }
        public string Woe_name { get; set; }
    }

    public class Places
    {
        public List<Place> Place { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public int Total { get; set; }
    }

    public class RootObject
    {
        public Places Places { get; set; }
        public string Stat { get; set; }
    }

}