using AutoMapper;
using Models.DTOs;
using Models.DTOs.UserDTOs;
using Models.Models;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BaseMaterial, BaseMaterialDTO>();
            CreateMap<RegisterDTO, User>();
            CreateMap<User, LoginResponseDTO>();
        }
    }
}
