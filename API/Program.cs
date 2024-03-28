using Logic.Interfaces;
using Logic.Logic;
using Models.Storage;
using Repository.Database;
using Repository.Interfaces;
using Repository.ModelRepositories;
using Microsoft.EntityFrameworkCore.Design;
using API.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDataInjectionServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.CustomOperationIds(d => d.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
       ? controllerActionDescriptor.MethodInfo.Name
       : d.ActionDescriptor.AttributeRouteInfo?.Name);
    //c.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Title = "Willu Backend API",
    //    Version = "v1",
    //    Description = "API for Willu application"
    //});
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddOpenApiDocument();

var app = builder.Build();

app.UseCors(corsBuilder =>
    corsBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")
);

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwaggerUi(options =>
//{
//    options.DocumentTitle = "Title";
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
