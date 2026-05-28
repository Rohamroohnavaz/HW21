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
    public class TakingTurnModelBuilderConfiguration : BaseModelBuilerConfiguration<TakingTurn>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<TakingTurn> builder)
        {
            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Center)
                .WithMany()
                .HasForeignKey(t => t.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Car)
                .WithMany()
                .HasForeignKey(t => t.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
