using HW21.DomainLayer.Models;
using HW21.Infrastructure.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<TechnicalExaminationCenter> TechnicalExaminationCenters { get; set; }
        public DbSet<TakingTurn> TakingTurns { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<TimeManaging> Times { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer("Data Source=MASTER\\MSSQLSERVER02;Initial Catalog=EFCore_HW21Db;TrustServerCertificate=True;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.ApplyConfiguration(new ProvinceModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new CityModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicalCenterModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new TimeManagingModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new UserModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelBuilderConfiguration());
            modelBuilder.ApplyConfiguration(new TakingTurnModelBuilderConfiguration());
        }
    }
}
