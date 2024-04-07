using API.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
