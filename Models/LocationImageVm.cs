namespace LocationSearchApplicationAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocationImageVM
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public byte[] Image { get; set; }
        public string ImageId { get; set; }
    }
}
