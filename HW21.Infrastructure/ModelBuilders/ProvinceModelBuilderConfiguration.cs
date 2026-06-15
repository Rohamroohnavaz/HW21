using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data.Seed_Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.ModelBuilders
{
    public class ProvinceModelBuilderConfiguration : BaseModelBuilerConfiguration<Province>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasData(SeedData.CreateProvince);
        }
    }
}
