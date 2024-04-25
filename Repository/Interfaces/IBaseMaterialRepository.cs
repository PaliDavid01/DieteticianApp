using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IBaseMaterialRepository : IRecipeRepository<BaseMaterial>
    {
        Task<BaseMaterial> GetAllExtended();
    }
}
