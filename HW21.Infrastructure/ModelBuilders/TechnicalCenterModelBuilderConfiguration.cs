using HW21.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.ModelBuilders
{
    public class TechnicalCenterModelBuilderConfiguration : BaseModelBuilerConfiguration<TechnicalExaminationCenter>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<TechnicalExaminationCenter> builder)
        {
            builder.Property(t => t.VisitTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.HasOne(t => t.City)
                .WithMany()
                .HasForeignKey(t => t.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Province)
                .WithMany()
                .HasForeignKey(t => t.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
