using API.Interfaces;
using API.Services;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Storage;
using Repository.Database;
using Repository.Interfaces;
using Repository.ModelRepositories;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataBaseContext>(opt =>
        {
            opt.UseSqlServer("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        });
        //services.AddTransient<IRepository<Material>, MaterialRepository>();
        services.AddTransient<IRepository<User>, UserRepository>();
        //services.AddTransient<IMaterialLogic, MaterialLogic>();
        services.AddTransient<IUserLogic, UserLogic>();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
