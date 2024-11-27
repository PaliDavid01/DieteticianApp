using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IRecipeRepository : ICRUDRepository<Recipe>
    {
        Task<IEnumerable<RecipeGenerateDataView>> ReadAllRecipeGenerateDataViewAsync();
    }
}