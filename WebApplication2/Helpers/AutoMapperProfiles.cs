using AutoMapper;
using Models.DTOs;
using Models.Storage;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MaterialDTO, Material>();
        }
    }
}
