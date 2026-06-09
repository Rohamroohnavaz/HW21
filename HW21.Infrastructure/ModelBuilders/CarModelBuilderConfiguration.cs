using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data.Seed_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.ModelBuilders
{
    public class CarModelBuilderConfiguration : BaseModelBuilerConfiguration<Car>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(c => c.ChassisNumber)
                .IsUnique();

            builder.HasOne(c => c.Owner)
                .WithMany(u => u.Cars)
                .IsRequired();

            builder.HasData(SeedData.CreateCar);
        }
    }
}
