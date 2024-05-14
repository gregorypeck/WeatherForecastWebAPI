using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using WeatherForecastWebAPI.DBContext;
using WeatherForecastWebAPI.ExceptionHandling;
using WeatherForecastWebAPI.Exceptions;
using WeatherForecastWebAPI.Models;
using WeatherForecastWebAPI.Queries.V2;
using WeatherForecastWebAPI.Service.V1;
using WeatherForecastWebAPI.Service.V2;
using WeatherForecastWebAPI.Validators.V2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(new GlobalExceptionFilterV1());
        options.Filters.Add<UnhandledExceptionFilterAttribute>();
    })
    .AddNewtonsoftJson();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        }
    );
    option.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        }
    );
});

builder.Services.AddDbContext<WeatherForecastInMemoryContext>(opt =>
    opt.UseInMemoryDatabase("WeatherForecastInMemoryDB"));


//This section below is for connection string 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeatherForecastMSSQLDBContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddTransient<WeatherForecastV1DataGenerator>();



builder.Services.AddScoped<GetWeatherForecastQueryValidatorV2>();
builder.Services.AddScoped<GetWeatherForecastLatestQueryValidatorV2>();
builder.Services.AddScoped<DeleteWeatherForecastQueryValidatorV2>();
builder.Services.AddScoped<UpdateWeatherForecastQueryValidatorV2>();

builder.Services.AddScoped<IWeatherForecastServiceV1, WeatherForecastServiceV1>();
builder.Services.AddScoped<IWeatherForecastServiceV2, WeatherForecastServiceV2>();



builder.Services.AddScoped<IValidator<AddWeatherForecastQueryV2>, AddWeatherForecastQueryValidatorV2>();
builder.Services.AddScoped<IValidator<DeleteWeatherForecastQueryV2>, DeleteWeatherForecastQueryValidatorV2>();
builder.Services.AddScoped<IValidator<GetWeatherForecastLatestQueryV2>, GetWeatherForecastLatestQueryValidatorV2>();
builder.Services.AddScoped<IValidator<GetWeatherForecastQueryV2>, GetWeatherForecastQueryValidatorV2>();
builder.Services.AddScoped<IValidator<UpdateWeatherForecastQueryV2>, UpdateWeatherForecastQueryValidatorV2>();

builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// seed data in inmemorydb, not preatty but is :)
var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

using (var scope = scopedFactory.CreateScope())
{
    var service = scope.ServiceProvider.GetService<WeatherForecastV1DataGenerator>();
    service.Seed();
}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

// login min api always ok
app.MapGet("/login", (string username) =>
{
    var claimsPrincipal = new ClaimsPrincipal(
      new ClaimsIdentity(
        new[] { new Claim(ClaimTypes.Name, username) },
        BearerTokenDefaults.AuthenticationScheme 
      )
    );

    return Results.SignIn(claimsPrincipal);
});

app.Run();
