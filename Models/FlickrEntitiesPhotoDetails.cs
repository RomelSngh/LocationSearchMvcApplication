using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationSearchApplicationAPI.Models.Flickr.PhotoDetails
{
    //photo detail
    public class Owner
    {
        public string Nsid { get; set; }
        public string Username { get; set; }
        public string Realname { get; set; }
        public string Location { get; set; }
        public string Iconserver { get; set; }
        public int Iconfarm { get; set; }
        public string Path_alias { get; set; }
    }

    public class Title
    {
        public string Content { get; set; }
    }

    public class Description
    {
        public string Content { get; set; }
    }

    public class Visibility
    {
        public int Ispublic { get; set; }
        public int Isfriend { get; set; }
        public int Isfamily { get; set; }
    }

    public class Dates
    {
        public string Posted { get; set; }
        public string Taken { get; set; }
        public string Takengranularity { get; set; }
        public string Takenunknown { get; set; }
        public string Lastupdate { get; set; }
    }

    public class Editability
    {
        public int Cancomment { get; set; }
        public int Canaddmeta { get; set; }
    }

    public class Publiceditability
    {
        public int Cancomment { get; set; }
        public int Canaddmeta { get; set; }
    }

    public class Usage
    {
        public int Candownload { get; set; }
        public int Canblog { get; set; }
        public int Canprint { get; set; }
        public int Canshare { get; set; }
    }

    public class Comments
    {
        public string Content { get; set; }
    }

    public class Notes
    {
        public List<object> Note { get; set; }
    }

    public class People
    {
        public int Haspeople { get; set; }
    }

    public class Tag
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Authorname { get; set; }
        public string Raw { get; set; }
        public string Content { get; set; }
        public int Machine_tag { get; set; }
    }

    public class Tags
    {
        public List<Tag> Tag { get; set; }
    }

    public class Neighbourhood
    {
        public string Content { get; set; }
        public string Place_id { get; set; }
        public string Woeid { get; set; }
    }

    public class Locality
    {
        public string Content { get; set; }
        public string Place_id { get; set; }
        public string Woeid { get; set; }
    }

    public class County
    {
        public string Content { get; set; }
        public string Place_id { get; set; }
        public string Woeid { get; set; }
    }

    public class Region
    {
        public string Content { get; set; }
        public string Place_id { get; set; }
        public string Woeid { get; set; }
    }

    public class Country
    {
        public string _content { get; set; }
        public string place_id { get; set; }
        public string woeid { get; set; }
    }

    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public string Context { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public Locality Locality { get; set; }
        public County County { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
        public string Place_id { get; set; }
        public string Woeid { get; set; }
    }

    public class Geoperms
    {
        public int Ispublic { get; set; }
        public int Iscontact { get; set; }
        public int Isfriend { get; set; }
        public int Isfamily { get; set; }
    }

    public class Url
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }

    public class Urls
    {
        public List<Url> Url { get; set; }
    }

    public class Photo
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public int Farm { get; set; }
        public string Dateuploaded { get; set; }
        public int Isfavorite { get; set; }
        public string License { get; set; }
        public string Safety_level { get; set; }
        public int Rotation { get; set; }
        public string Originalsecret { get; set; }
        public string Originalformat { get; set; }
        public Owner Owner { get; set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public Visibility Visibility { get; set; }
        public Dates Dates { get; set; }
        public string Views { get; set; }
        public Editability Editability { get; set; }
        public Publiceditability Publiceditability { get; set; }
        public Usage Usage { get; set; }
        public Comments Comments { get; set; }
        public Notes Notes { get; set; }
        public People People { get; set; }
        public Tags Tags { get; set; }
        public Location Location { get; set; }
        public Geoperms Geoperms { get; set; }
        public Urls Urls { get; set; }
        public string Media { get; set; }
    }

    public class RootObject
    {
        public Photo Photo { get; set; }
        public string Stat { get; set; }
    }
}