using Logic.Interfaces;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Interfaces;
using Repository.ModelRepositories;

namespace API.Extensions
{
    public static class DataInjection
    {
        public static IServiceCollection AddDataInjectionServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataBaseContext>(opt =>
            {
                opt.UseSqlServer("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            });
            //services.AddTransient<IRepository<Material>, MaterialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IAllergenMaterialRepository, AllergenMaterialRepository>();
            services.AddScoped<IAllergenRepository, AllergenRepository>();
            services.AddScoped<IBaseMaterialRepository, BaseMaterialRepository>();
            services.AddScoped<IEcodeRepository, EcodeRepository>();
            services.AddScoped<IMaterialGroupRepository, MaterialGroupRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IVitaminRepository, VitaminRepository>();
            services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IMealRecipeRepository, MealRecipeRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IWeekMenuRepository, WeekMenuRepository>();
            services.AddScoped<IWeekOrderRepository, WeekOrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDayOrderRepository, DayOrderRepository>();
            services.AddScoped<IDayMenuRepository, DayMenuRepository>();
            services.AddScoped<IWeekMenuGenerateDataAllergenRepository, WeekMenuGenerateDataAllergenRepository>();
            services.AddScoped<IWeekMenuGenerateDataRepository, WeekMenuGenerateDataRepository>();
            services.AddScoped<IAgeCategoryRepository, AgeCategoryRepository>();



            //services.AddTransient<IMaterialLogic, MaterialLogic>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IRoleLogic, RoleLogic>();
            services.AddScoped<IUserRoleLogic, UserRoleLogic>();
            services.AddScoped<IAllergenMaterialLogic, AllergenMaterialLogic>();
            services.AddScoped<IAllergenLogic, AllergenLogic>();
            services.AddScoped<IBaseMaterialLogic, BaseMaterialLogic>();
            services.AddScoped<IEcodeLogic, EcodeLogic>();
            services.AddScoped<IMaterialGroupLogic, MaterialGroupLogic>();
            services.AddScoped<IStockLogic, StockLogic>();
            services.AddScoped<IVitaminLogic, VitaminLogic>();
            services.AddScoped<IRecipeCategoryLogic, RecipeCategoryLogic>();
            services.AddScoped<IRecipeLogic, RecipeLogic>();
            services.AddScoped<IIngredientLogic, IngredientLogic>();
            services.AddScoped<IMealLogic, MealLogic>();
            services.AddScoped<IMealRecipeLogic, MealRecipeLogic>();
            services.AddScoped<IWeekMenuLogic, WeekMenuLogic>();
            services.AddScoped<IWeekOrderLogic, WeekOrderLogic>();
            services.AddScoped<ICustomerLogic, CustomerLogic>();
            services.AddScoped<IDayOrderLogic, DayOrderLogic>();
            services.AddScoped<IDayMenuLogic, DayMenuLogic>();
            services.AddScoped<IWeekMenuGenerateDataLogic, WeekMenuGenerateDataLogic>();
            services.AddScoped<IWeekMenuGenerateDataAllergenLogic, WeekMenuGenerateDataAllergenLogic>();
            services.AddScoped<IAgeCategoryLogic, AgeCategoryLogic>();

            return services;
        }
    }
}
