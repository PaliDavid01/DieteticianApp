using API.Interfaces;
using API.Services;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Models.Storage;
using Repository.Database;
using Repository.Interfaces;
using Repository.ModelRepositories;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddTransient<IRepository<Material>, MaterialRepository>();
        services.AddTransient<IRepository<AppUser>, UserRepository>();
        services.AddTransient<IMaterialLogic, MaterialLogic>();
        services.AddTransient<ILogic<AppUser>, UserLogic>();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
