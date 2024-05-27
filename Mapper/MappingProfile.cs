using AutoMapper;
using LocationSearchApiMVCWithUsers.Models;
using LocationSearchApplicationAPI.Models;

namespace LocationSearchApiMVCWithUsers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<LocationSearchApplicationAPI.Models.FourSquare.Venue, LocationSearchApplicationAPI.Models.Venue>()
               .ForMember(x => x.Description, opt => opt.MapFrom(src => (src.Categories.Count >= 1) ? src.Categories[0].Name : ""))
               .ForMember(x => x.Latitude, opt => opt.MapFrom(src => src.Location.Lat))
               .ForMember(x => x.Longitude, opt => opt.MapFrom(src => src.Location.Lng))
               .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(x => x.Url, opt => opt.MapFrom(src => src.Url))
               .ForMember(x => x.Dislike, opt => opt.MapFrom(src => src.HasPerk))
               .ForMember(x => x.Venueid, opt => opt.MapFrom(src => src.Id))
               .ForMember(x => x.Id, opt => opt.MapFrom(src => 0));

            CreateMap<LocationImage, LocationImageVM>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(x => x.ImageId, opt => opt.MapFrom(src => src.ImageId))
                 .ForMember(x => x.VenueName, opt => opt.MapFrom(src => src.PhotoTitle));
            // CreateMap<UserDto, User>();
        }
    }
}
