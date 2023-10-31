using AutoMapper;
using Models.DTOs;
using Models.DTOs.UserDTOs;
using Models.Storage;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MaterialDTO, Material>();
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
