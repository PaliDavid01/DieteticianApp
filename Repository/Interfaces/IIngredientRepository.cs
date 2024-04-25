using Models.Models;
using Repository.Interfaces.GenericInterfaces;

namespace Repository.Interfaces
{
    public interface IIngredientRepository : IRecipeRepository<Ingredient>
    {
    }
}