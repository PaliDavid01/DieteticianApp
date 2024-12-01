using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories.GenericRepository;

namespace Repository.ModelRepositories
{
    public class WeekMenuRepository : CRUDRepository<WeekMenu>, IWeekMenuRepository
    {
        private readonly DataBaseContext _dbContext;
        public WeekMenuRepository(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public WeekMenu InitWeekMenu(WeekMenu weekMenu)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] meals = { "Breakfast", "Brunch", "Lunch", "AfternoonSnack", "Dinner" };
            try
            {
                _dbContext.Database.BeginTransaction();
                for (int i = 0; i < days.Length; i++)
                {
                    DayMenu dayMenu = new DayMenu()
                    {
                        DayMenuName = days[i],
                        DayMenuDate = DateTime.Now
                    };
                    for (int j = 0; j < meals.Length; j++)
                    {
                        dayMenu.GetType().GetProperty(meals[j] + "Id").SetValue(dayMenu, 1);
                    }
                    _dbContext.DayMenus.Add(dayMenu);
                    _dbContext.SaveChanges();
                    weekMenu.GetType().GetProperty(days[i] + "Id").SetValue(weekMenu, dayMenu.DayMenuId);
                }
                _dbContext.WeekMenus.Add(weekMenu);
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
                return weekMenu;
            }
            catch (Exception e)
            {
                _dbContext.Database.RollbackTransaction();
                throw e;
            }
        }

        public Task<int> CreateWeekMenuDTO(WeekMenuDTO weekMenuDTO)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] meals = { "Breakfast", "Brunch", "Lunch", "AfternoonSnack", "Dinner" };

            _dbContext.Database.BeginTransaction();
            try
            {
                WeekMenu weekMenu = new WeekMenu()
                {
                    WeekMenuName = weekMenuDTO.WeekMenuName,
                    WeekMenuStartDate = weekMenuDTO.WeekMenuStartDate ?? DateTime.Now,
                    WeekMenuEndDate = weekMenuDTO.WeekMenuEndDate ?? DateTime.Now
                };

                for (int i = 0; i < days.Length; i++)
                {
                    DayMenuDTO daymenuDTO = (DayMenuDTO)weekMenuDTO.GetType().GetProperty(days[i]).GetValue(weekMenuDTO);
                    DayMenu dayMenu = new DayMenu()
                    {
                        DayMenuName = daymenuDTO.DayMenuName,
                        DayMenuDate = daymenuDTO.DayMenuDate ?? DateTime.Now
                    };
                    for (int j = 0; j < meals.Length; j++)
                    {
                        MealRecipeDTO mealRecipeDTO = (MealRecipeDTO)daymenuDTO.GetType().GetProperty(meals[i]).GetValue(daymenuDTO);
                        MealRecipe mealRecipe = new MealRecipe()
                        {
                            Quantity = mealRecipeDTO.Quantity ?? 0
                        };
                        Meal meal = new Meal()
                        {
                            MealName = mealRecipeDTO.Meal.MealName,
                            ServingCount = mealRecipeDTO.Meal.ServingCount,
                            MealDescription = mealRecipeDTO.Meal.MealDescription
                        };
                        _dbContext.Meals.Add(meal);
                        _dbContext.SaveChanges();
                        mealRecipe.RecipeId = mealRecipeDTO.RecipeId ?? 0;
                        mealRecipe.MealId = meal.MealId;
                        _dbContext.MealRecipes.Add(mealRecipe);
                        _dbContext.SaveChanges();
                        dayMenu.GetType().GetProperty(meals[j] + "Id").SetValue(dayMenu.DayMenuId, meal.MealId);
                    }
                    _dbContext.DayMenus.Add(dayMenu);
                    _dbContext.SaveChanges();
                    weekMenu.GetType().GetProperty(days[i] + "Id").SetValue(weekMenu.WeekMenuId, dayMenu.DayMenuId);

                }
                _dbContext.WeekMenus.Add(weekMenu);
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
                return Task.FromResult(weekMenu.WeekMenuId);
            }
            catch (Exception e)
            {
                _dbContext.Database.RollbackTransaction();
                throw e;
            }

        }

        public async Task<WeekMenuDTO> GetWeekMenuDTO(int id)
        {
            var weekMenu = _dbContext.WeekMenus
                .Where(wm => wm.WeekMenuId == id)
                .Select(wm => new WeekMenuDTO()
                {
                    Monday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        }).FirstOrDefault(),
                    Tuesday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        })
                        .FirstOrDefault(),
                    Wednesday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        })
                        .FirstOrDefault(),
                    Thursday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        })
                        .FirstOrDefault(),
                    Friday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        })
                        .FirstOrDefault(),
                    Saturday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        })
                        .FirstOrDefault(),
                    Sunday = _dbContext.DayMenus
                        .Where(dm => dm.DayMenuId == wm.MondayId)
                        .Select(dm => new DayMenuDTO()
                        {
                            Breakfast = _dbContext.Meals
                                .Where(m => m.MealId == dm.BreakfastId)
                                .Select(m => new MealDTO()
                                {
                                    MealId = m.MealId,
                                    MealName = m.MealName,
                                    ServingCount = m.ServingCount,
                                    MealDescription = m.MealDescription
                                }).FirstOrDefault(),
                            Brunch = _dbContext.Meals.Where(m => m.MealId == dm.BreakfastId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Lunch = _dbContext.Meals.Where(m => m.MealId == dm.LunchId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            AfternoonSnack = _dbContext.Meals.Where(m => m.MealId == dm.AfternoonSnackId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault(),
                            Dinner = _dbContext.Meals.Where(m => m.MealId == dm.DinnerId).Select(m => new MealDTO()
                            {
                                MealId = m.MealId,
                                MealName = m.MealName,
                                ServingCount = m.ServingCount,
                                MealDescription = m.MealDescription
                            }).FirstOrDefault()
                        }).FirstOrDefault()
                });
            return await weekMenu.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<WeekMenu>> ReadAllByCustomerPreferences(int customerId)
        {
            var customer = await _dbContext.Customers.Where(u => u.CustomerId == customerId).FirstOrDefaultAsync();
            var customerAllergens = await _dbContext.AllergenCustomers.Where(ca => ca.CustomerId == customerId).ToListAsync();
            if (customer == null)
            {
                throw new Exception("User not found");
            }

            var weekMenus = await _dbContext.WeekMenus.Join(_dbContext.WeekMenuGenerateData,
                wm => wm.WeekMenuId,
                wmgd => wmgd.WeekMenuId,
                (wm, wmgd) => new { wm, wmgd })
                .Join(_dbContext.WeekMenuGenerateDataAllergens,
                wm_wmgd => wm_wmgd.wmgd.WeekMenuGenerateDataId,
                wmgda => wmgda.WeekMenuGenerateDataId,
                (wm_wmgd, wmgda) => new { wm_wmgd, wmgda }).ToListAsync();

            weekMenus.Where(wm => wm.wm_wmgd.wmgd.AgeCategoryId == customer.AgeCategoryId);
            weekMenus.Where(wm => customerAllergens.Select(ca => ca.AllergenId).Any(t => t == wm.wmgda.AllergenId));

            return weekMenus.Select(wm => wm.wm_wmgd.wm).ToList();
        }
    }
}
