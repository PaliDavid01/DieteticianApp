using AutoMapper;
using Models.DTOs;
using Models.DTOs.UserDTOs;
using Models.Models;
using Models.Storage;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MaterialPostDTO, Material>();
            CreateMap<RegisterDTO, User>();
            CreateMap<User, LoginResponseDTO>();
        }
    }
}
