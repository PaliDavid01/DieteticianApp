using Models;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class DayMenuRepository : CRUDRepository<DayMenu>, IDayMenuRepository
    {
        private string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public DayMenuRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId)
        {
            return (await _dbContext.GetProcedures().GetDayMenuMacroDataAsync(dayMenuId)).First();
        }
        public async Task SaveGeneratedDaymenu(int dayMenuId, Dictionary<MealType, MealRecipe> dayMenu)
        {
            _dbContext.Database.BeginTransaction();
            try
            {
                Meal meal;
                MealRecipe mealRecipe;
                DayMenu dayMenuElement = _dbContext.DayMenus.Find(dayMenuId);
                foreach (var item in dayMenu)
                {
                    meal = new Meal();
                    mealRecipe = item.Value;
                    meal.ServingCount = 1;
                    meal.MealName = "Generated" + item.Key.ToString();
                    meal.MealDescription = "Generated" + item.Key.ToString();
                    _dbContext.Meals.Add(meal);
                    _dbContext.SaveChanges();
                    dayMenuElement.GetType().GetProperty(item.Key.ToString() + "Id").SetValue(dayMenuElement, meal.MealId);
                    mealRecipe.MealId = meal.MealId;
                    _dbContext.MealRecipes.Add(mealRecipe);
                    _dbContext.SaveChanges();
                }
                dayMenuElement.DayMenuName = "Generated";
                _dbContext.DayMenus.Update(dayMenuElement);
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                _dbContext.Database.RollbackTransaction();
                throw new Exception(e.Message);
            }

        }
    }

}
