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

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region JWT Token cfg
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
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

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
/*
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
*/
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

app.MapGroup("/account").MapIdentityApi<ApplicationUser>();


app.MapGroup("/garage")
    .MapGet("/{{guid}}", async (Guid guid, GarageService service) =>
    {
        var garage = await service.Get(guid);
        return Results.Ok(garage);
    });

app.UseSwaggerUI();
app.Run();