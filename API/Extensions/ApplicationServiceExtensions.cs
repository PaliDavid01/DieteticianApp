using API.Interfaces;
using API.Services;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
