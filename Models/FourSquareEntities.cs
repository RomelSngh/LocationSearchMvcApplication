using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationSearchApplicationAPI.Models.FourSquare
{
    public class Meta
    {
        public int Code { get; set; }
        public string RequestId { get; set; }
    }

    public class Contact
    {
        public string? Phone { get; set; }
        public string FormattedPhone { get; set; }
        public string Twitter { get; set; }
    }

    public class LabeledLatLng
    {
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string PostalCode { get; set; }
        public string Cc { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<string> FormattedAddress { get; set; }
        public string Address { get; set; }
        public string CrossStreet { get; set; }
        public List<LabeledLatLng> LabeledLatLngs { get; set; }
        public string City { get; set; }
    }

    public class Stats
    {
        public int CheckinsCount { get; set; }
        public int UsersCount { get; set; }
        public int TipCount { get; set; }
    }

    public class BeenHere
    {
        public int UnconfirmedCount { get; set; }
        public bool Marked { get; set; }
        public int LastCheckinExpiredAt { get; set; }
    }

    public class Specials
    {
        public int Count { get; set; }
        public List<object> Items { get; set; }
    }

    public class HereNow
    {
        public int Count { get; set; }
        public string Summary { get; set; }
        public List<object> Groups { get; set; }
    }

    public class VenuePage
    {
        public string Id { get; set; }
    }

    public class Venue
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public List<Category> Categories { get; set; }
        public bool Verified { get; set; }
        public Stats Stats { get; set; }
        public BeenHere BeenHere { get; set; }
        public Specials Specials { get; set; }
        public HereNow HereNow { get; set; }
        public string ReferralId { get; set; }
        public List<object> VenueChains { get; set; }
        public bool HasPerk { get; set; }
        public string Url { get; set; }
        public bool? AllowMenuUrlEdit { get; set; }
        public VenuePage VenuePage { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public Icon Icon { get; set; }
        public bool Primary { get; set; }
    }

    public class Center
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Ne
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Sw
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Bounds
    {
        public Ne Ne { get; set; }
        public Sw Sw { get; set; }
    }

    public class Geometry
    {
        public Center Center { get; set; }
        public Bounds Bounds { get; set; }
    }

    public class Feature
    {
        public string Cc { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string MatchedName { get; set; }
        public string HighlightedName { get; set; }
        public int WoeType { get; set; }
        public string Slug { get; set; }
        public string Id { get; set; }
        public string LongId { get; set; }
        public Geometry Geometry { get; set; }
    }

    public class Geocode
    {
        public string What { get; set; }
        public string Where { get; set; }
        public Feature Feature { get; set; }
        public List<object> Parents { get; set; }
    }

    public class Response
    {
        public List<Venue> Venues { get; set; }
        public bool Confident { get; set; }
        public Geocode Geocode { get; set; }
    }

    public class RootObject
    {
        public Meta Meta { get; set; }
        public Response Response { get; set; }
    }
}