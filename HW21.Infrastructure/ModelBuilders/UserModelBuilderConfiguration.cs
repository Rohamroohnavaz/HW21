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
    public class UserModelBuilderConfiguration : BaseModelBuilerConfiguration<User>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.HasMany(u => u.Cars)
                .WithOne(c => c.Owner)
                .IsRequired();

            builder.HasData(SeedData.CreateUser);
        }
    }
}
