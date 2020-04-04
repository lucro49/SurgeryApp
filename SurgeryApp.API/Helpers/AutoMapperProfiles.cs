using System.Linq;
using AutoMapper;
using SurgeryApp.API.Dtos;
using SurgeryApp.API.Models;

namespace SurgeryApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(r => r.PhotosUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(r => r.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetialedDto>()   
            .ForMember(r => r.PhotosUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
             .ForMember(r => r.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}