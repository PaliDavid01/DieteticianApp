using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class MealRepository : CRUDRepository<Meal>, IMealRepository
    {
        public MealRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }
        public int CreateWithReturnId(Meal meal)
        {
            var localMeal = new Meal();
            localMeal.MealName = meal.MealName;
            localMeal.MealDescription = meal.MealDescription;
            _dbContext.Meals.Add(localMeal);
            _dbContext.SaveChanges();
            return localMeal.MealId;
        }

        public async Task<GetMealMacroDataResult> GetMealMacroData(int mealId)
        {
            return (await _dbContext.GetProcedures().GetMealMacroDataAsync(mealId)).First();
        }
    }
}
