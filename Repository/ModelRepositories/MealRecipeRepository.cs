using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class MealRecipeRepository : CRUDRepository<MealRecipe>, IMealRecipeRepository
    {
        public MealRecipeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<GetMealRecipe>> GetAllDTO(int mealId)
        {
            return await _dbContext.MealRecipes.Where(t => t.MealId == mealId).Join(_dbContext.Recipes, mr => mr.RecipeId, r => r.RecipeId, (mr, r) => new GetMealRecipe
            {
                MealRecipeId = mr.MealRecipeId,
                MealId = mr.MealId,
                RecipeId = mr.RecipeId,
                Quantity = mr.Quantity,
                RecipeName = r.RecipeName
            }).ToListAsync(); ;
        }
    }
}
