using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TinyGarage.Api.Services.Abstract;
using TinyGarage.Api.Services;
using TinyGarage.Models;
using TinyGarage.Repositories;
using TinyGarage.Repositories.Abstract;
using TinyGarage.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TinyGarage.Server.BindingModels;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region JWT Token cfg
/*
builder.Services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
*/
builder.Services
    .AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
#endregion
#region DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion
#region Dependency injection
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IDataRepository,  DataRepository>();
builder.Services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddScoped<IGarageService, GarageService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();

#endregion
var app = builder.Build();
#region Apply pending EF migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseRouting();
//app.UseAuthorization();
app.MapGroup("/api/account").MapIdentityApi<ApplicationUser>();

#region Garage Api
app.MapGroup("/api/garage")
    .MapGet("/{guid}", async (string guid, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IGarageService>();
        var garage = await service.Get(Guid.Parse(guid));
        return Results.Ok(garage);
    });

app.MapGroup("/api/garage")
    .MapGet("/all", (IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IGarageService>();
        var garages = service.GetAll();
        return Results.Ok(garages);
    });

app.MapGroup("/api/garage")
    .MapPost("/create", async ([FromBody] GarageCreateBindingModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IGarageService>();
        var id = await service.Create(model);
        return Results.Created($"/garage/{id}", id);
    });

app.MapGroup("/api/garage")
    .MapPost("/update/", async (Garage model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IGarageService>();
        var id = await service.Update(model);
        return Results.Created($"/garage/{id}", id);
    });
#endregion

#region Model Api
app.MapGroup("/api/model")
    .MapGet("/{guid}", async (string guid, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IModelService>();
        var model = await service.Get(Guid.Parse(guid));
        return Results.Ok(model);
    });

app.MapGroup("/api/model")
    .MapGet("/all", (IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IModelService>();
        var models = service.GetAll();
        return Results.Ok(models);
    });

app.MapGroup("/api/model")
    .MapPost("/create", async ([FromBody] CarModelCreateBindingModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IModelService>();
        var id = await service.Create(model);
        return Results.Created($"/model/{id}", id);
    });

app.MapGroup("/api/model")
    .MapPost("/update/", async (CarModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IModelService>();
        var id = await service.Update(model);
        return Results.Created($"/model/{id}", id);
    });
#endregion

#region Car Api
app.MapGroup("/api/car")
    .MapGet("/{guid}", async (string guid, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var car = await service.Get(Guid.Parse(guid));
        return Results.Ok(car);
    });

app.MapGroup("/api/car")
    .MapGet("/all", (IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var cars = service.GetAll();
        return Results.Ok(cars);
    });

app.MapGroup("/api/car")
    .MapPost("/create", async ([FromBody] CarCreateBindingModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var id = await service.Create(model);
        return Results.Created($"/car/{id}", id);
    });

app.MapGroup("/api/car")
    .MapPost("/update/", async (Car model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var id = await service.Update(model);
        return Results.Created($"/car/{id}", id);
    });
#endregion

#region Manufacturer Api
app.MapGroup("/api/manufacturer")
    .MapGet("/{guid}", async (string guid, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IManufacturerService>();
        var manufacturer = await service.Get(Guid.Parse(guid));
        return Results.Ok(manufacturer);
    });

app.MapGroup("/api/manufacturer")
    .MapGet("/all", (IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IManufacturerService>();
        var manufacturers = service.GetAll();
        return Results.Ok(manufacturers);
    });

app.MapGroup("/api/manufacturer")
    .MapPost("/create", async ([FromBody] ManufacturerCreateBindingModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IManufacturerService>();
        var id = await service.Create(model);
        return Results.Created($"/manufacturer/{id}", id);
    });

app.MapGroup("/api/manufacturer")
    .MapPost("/update/", async (Manufacturer model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<IManufacturerService>();
        var id = await service.Update(model);
        return Results.Created($"/manufacturer/{id}", id);
    });
#endregion

#region Collection Api
app.MapGroup("/api/collection")
    .MapGet("/{guid}", async (string guid, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var collection = await service.Get(Guid.Parse(guid));
        return Results.Ok(collection);
    });

app.MapGroup("/api/collection")
    .MapGet("/all", (IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICarService>();
        var collections = service.GetAll();
        return Results.Ok(collections);
    });

app.MapGroup("/api/collection")
    .MapPost("/create", async ([FromBody] ModelCollectionCreateBindingModel model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICollectionService>();
        var id = await service.Create(model);
        return Results.Created($"/collection/{id}", id);
    });

app.MapGroup("/api/collection")
    .MapPost("/update/", async (ModelCollection model, IServiceProvider provider) =>
    {
        var service = provider.GetRequiredService<ICollectionService>();
        var id = await service.Update(model);
        return Results.Created($"/collection/{id}", id);
    });
#endregion

app.UseSwaggerUI();
app.Run();