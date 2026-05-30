using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.MainRepositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HW21.Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new AppDbContext();

            var userRepo = new UserRepository(dbContext);
            var carRepo = new CarRepository(dbContext);
            var cityRepo = new CityRepository(dbContext);
            var provinceRepo = new ProvinceRepository(dbContext);
            var centerRepo = new CenterRepository(dbContext);
            var takingTurnRepo = new TakingTurnRepository(dbContext);

            var user = new User("Rohi86", "123456", 9351305594);
            await userRepo.AddAsync(user);

            var users = await dbContext.Users
                .Where(u => u.CreatedAt > DateTime.UtcNow.AddDays(-30))
                .ToListAsync();

            Console.WriteLine(JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true,
            }));
        }
    }
}
