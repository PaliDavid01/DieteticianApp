using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class DayMenuLogic : CRUDLogic<DayMenu>, IDayMenuLogic
    {
        private readonly IDayMenuRepository _repository;
        private readonly IWeekMenuRepository _weekMenuRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IWeekMenuGenerateDataRepository _weekMenuGenerateDataRepository;
        private readonly IAgeCategoryRepository _ageCategoryRepository;
        private readonly IWeekMenuGenerateDataAllergenRepository _weekMenuGenerateDataAllergenRepository;
        public DayMenuLogic(IDayMenuRepository repository,
            IWeekMenuGenerateDataAllergenRepository weekMenuGenerateDataAllergenRepository,
            IWeekMenuRepository weekMenuRepository,
            IRecipeRepository recipeRepository,
            IWeekMenuGenerateDataRepository weekMenuGenerateDataRepository,
            IAgeCategoryRepository ageCategoryRepository) : base(repository)
        {
            _repository = repository;
            _weekMenuRepository = weekMenuRepository;
            _recipeRepository = recipeRepository;
            _weekMenuGenerateDataRepository = weekMenuGenerateDataRepository;
            _ageCategoryRepository = ageCategoryRepository;
            _weekMenuGenerateDataAllergenRepository = weekMenuGenerateDataAllergenRepository;

        }

        public Task<IEnumerable<DayMenu>> GetDayMenuByWeekMenuId(int weekMenuId)
        {
            return _repository.GetDayMenuByWeekMenuId(weekMenuId);
        }

        public Task<GetDayMenuMacroDataResult> GetGetDayMenuMacroData(int dayMenuId)
        {
            return _repository.GetGetDayMenuMacroData(dayMenuId);
        }

        public async Task SaveGeneratedDaymenu(int dayMenuId, Dictionary<MealType, MealRecipe> dayMenu)
        {
            await _repository.SaveGeneratedDaymenu(dayMenuId, dayMenu);
        }

        public async Task<Dictionary<MealType, ICollection<MealRecipeDTO>>> GenerateDayMenu(int weekMenuId)
        {
            var weekMenu = _weekMenuRepository.Read(weekMenuId);
            var generateData = _weekMenuGenerateDataRepository.GetByWeekMenuId(weekMenuId);
            var ageCategory = _ageCategoryRepository.Read(generateData.AgeCategoryId);
            var allergens = _weekMenuGenerateDataAllergenRepository.GetByWeekMenuGenerateDataId(generateData.WeekMenuGenerateDataId).Select(t => t.AllergenId.ToString());

            var recipes = await _recipeRepository.ReadAllAsync();
            var recipeGenData = await _recipeRepository.ReadAllRecipeGenerateDataViewAsync();
            foreach (var allergen in allergens)
            {
                recipes = recipes.Where(r => recipeGenData.First(t => t.RecipeId == r.RecipeId).AllergenIds is not null ? recipeGenData.First(t => t.RecipeId == r.RecipeId).AllergenIds.Split(',').Any(t => t == allergen) : true);
            }

            var seed = new Random(DateTime.Now.Microsecond);
            return await Task.Run(() =>
            {
                return Generate(recipes, ageCategory, seed);
            });
        }
        // a method that generates a day menu
        public Dictionary<MealType, ICollection<MealRecipeDTO>> Generate(IEnumerable<Recipe> recipes, AgeCategory ageCategory, Random random)
        {
            Dictionary<MealType, ICollection<MealRecipeDTO>> prevGeneratedDayMenu = new Dictionary<MealType, ICollection<MealRecipeDTO>>
            {
                { MealType.Breakfast, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                    quantity = random.Next(1, 10),
                    Recipe = recipes.Where(t => t.RecipeCategoryId == 1).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 1).Count())] } }
                },
                { MealType.Brunch, new List<MealRecipeDTO>(){ new MealRecipeDTO(){
                    quantity = random.Next(1, 10),
                    Recipe = recipes.Where(t => t.RecipeCategoryId == 5).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 5).Count())] } }
                },
                { MealType.Lunch, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                    quantity = random.Next(1, 10),
                    Recipe = recipes.Where(t => t.RecipeCategoryId == 2).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 2).Count())] } }
                },
                { MealType.AfternoonSnack, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                    quantity = random.Next(1, 10),
                    Recipe = recipes.Where(t => t.RecipeCategoryId == 5).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 5).Count())] } }
                },
                { MealType.Dinner, new List<MealRecipeDTO>() { new MealRecipeDTO() {
                    quantity = random.Next(1, 10),
                    Recipe = recipes.Where(t => t.RecipeCategoryId == 3).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 3).Count())] } }
                }
            };
            // BreakFast
            var generatedDayMenu = new Dictionary<MealType, ICollection<MealRecipeDTO>>();
            var evaluation = DayMenuFittness(ageCategory, prevGeneratedDayMenu);
            var counter = 10000;
            while (evaluation.Values.Any(t => t > (decimal)1.1 || t < (decimal)0.9) && counter > 0)
            {
                generatedDayMenu = new Dictionary<MealType, ICollection<MealRecipeDTO>>
                {
                    { MealType.Breakfast, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                        quantity = prevGeneratedDayMenu.GetValueOrDefault(MealType.Breakfast).First().quantity / evaluation.GetValueOrDefault(MealType.Breakfast),
                        Recipe = recipes.Where(t => t.RecipeCategoryId == 1).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 1).Count())] } }
                    },
                    { MealType.Brunch, new List<MealRecipeDTO>(){ new MealRecipeDTO(){
                        quantity = prevGeneratedDayMenu.GetValueOrDefault(MealType.Brunch).First().quantity / evaluation.GetValueOrDefault(MealType.Brunch),
                        Recipe = recipes.Where(t => t.RecipeCategoryId == 5).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 5).Count())] } }
                    },
                    { MealType.Lunch, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                        quantity = prevGeneratedDayMenu.GetValueOrDefault(MealType.Lunch).First().quantity / evaluation.GetValueOrDefault(MealType.Lunch),
                        Recipe = recipes.Where(t => t.RecipeCategoryId == 2).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 2).Count())] } }
                    },
                    { MealType.AfternoonSnack, new List<MealRecipeDTO>() { new MealRecipeDTO(){
                        quantity = prevGeneratedDayMenu.GetValueOrDefault(MealType.AfternoonSnack).First().quantity / evaluation.GetValueOrDefault(MealType.AfternoonSnack),
                        Recipe = recipes.Where(t => t.RecipeCategoryId == 5).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 5).Count())] } }
                    },
                    { MealType.Dinner, new List<MealRecipeDTO>() { new MealRecipeDTO() {
                        quantity = prevGeneratedDayMenu.GetValueOrDefault(MealType.Dinner).First().quantity / evaluation.GetValueOrDefault(MealType.Dinner),
                        Recipe = recipes.Where(t => t.RecipeCategoryId == 3).ToList()[random.Next(0, recipes.Where(t => t.RecipeCategoryId == 3).Count())] } }
                    }
                };
                evaluation = DayMenuFittness(ageCategory, generatedDayMenu);
                prevGeneratedDayMenu = generatedDayMenu;
                counter--;
            }
            generatedDayMenu.Values.ToList().ForEach(t => t.First().quantity = Decimal.Round(t.First().quantity, 2));
            return generatedDayMenu;

        }

        public Dictionary<MealType, decimal> DayMenuFittness(AgeCategory ageCategory, Dictionary<MealType, ICollection<MealRecipeDTO>> generatedDayMenu)
        {
            return new Dictionary<MealType, decimal>
            {
                { MealType.Breakfast, (generatedDayMenu.GetValueOrDefault(MealType.Breakfast).Select(x => x.Recipe.RecipeCalories * x.quantity).Sum() ?? 1) / Convert.ToDecimal(ageCategory.MaxDailyCalories * 0.25)},
                { MealType.Brunch, (generatedDayMenu.GetValueOrDefault(MealType.Brunch).Select(x => x.Recipe.RecipeCalories * x.quantity).Sum() ?? 1) / Convert.ToDecimal(ageCategory.MaxDailyCalories * 0.10)},
                { MealType.Lunch, (generatedDayMenu.GetValueOrDefault(MealType.Lunch).Select(x => x.Recipe.RecipeCalories * x.quantity).Sum() ?? 1) / Convert.ToDecimal(ageCategory.MaxDailyCalories * 0.35) },
                { MealType.AfternoonSnack, (generatedDayMenu.GetValueOrDefault(MealType.AfternoonSnack).Select(x => x.Recipe.RecipeCalories * x.quantity).Sum() ?? 1) / Convert.ToDecimal(ageCategory.MaxDailyCalories * 0.10)},
                { MealType.Dinner, (generatedDayMenu.GetValueOrDefault(MealType.Dinner).Select(x => x.Recipe.RecipeCalories * x.quantity).Sum() ?? 1) / Convert.ToDecimal(ageCategory.MaxDailyCalories * 0.20)}
            };
        }

        public class MealRecipeDTO
        {
            public int RecipeId { get; set; }
            public decimal quantity { get; set; }
            public Recipe Recipe { get; set; }
        }
    }
}
