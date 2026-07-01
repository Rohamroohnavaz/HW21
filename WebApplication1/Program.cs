using HW21.Infrastructure.Data;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.MainRepositories.Repos;
using HW21.Service.InterfaceServices;
using HW21.Service.MainServices;
using HW21.Service.MainServices.Caching;
using HW21.Service.MainServices.Redis;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetConnectionString("Redis");
    opt.InstanceName = "HW21:";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TakingTurnService>();
builder.Services.AddScoped<ITakingTurnService, TakingTurnService>();
builder.Services.AddScoped<ITakingTurnRepository, TakingTurnRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICenterRepository, CenterRepository>();
builder.Services.AddScoped<ICenterService, CenterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGetEmptyTimeSpacesService, GetEmptyTimeSpacesService>();
builder.Services.AddScoped<IRedisService, RedisService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
