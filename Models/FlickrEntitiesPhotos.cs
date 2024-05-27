using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationSearchApplicationAPI.Models.Flickr.Photos
{
    //photo
    public class Photo
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public int Farm { get; set; }
        public string Title { get; set; }
        public int Ispublic { get; set; }
        public int Isfriend { get; set; }
        public int Isfamily { get; set; }
    }

    public class Photos
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Perpage { get; set; }
        public string Total { get; set; }
        public List<Photo> Photo { get; set; }
    }

    public class RootObject
    {
        public Photos Photos { get; set; }
        public string Stat { get; set; }
    }  
}