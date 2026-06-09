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
    public class CityModelBuilderConfiguration : BaseModelBuilerConfiguration<City>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(c => c.Province)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedData.CreateCity);
        }
    }
}
