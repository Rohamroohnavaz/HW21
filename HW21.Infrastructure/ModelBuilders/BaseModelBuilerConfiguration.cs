using HW21.DomainLayer.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.ModelBuilders
{
    public abstract class BaseModelBuilerConfiguration<T> :
        IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.CreatedAt);
            builder.HasQueryFilter(e => e.IsDeleted == false);

            ApplyEntityConfiguration(builder);
        }

        protected abstract void ApplyEntityConfiguration(EntityTypeBuilder<T> builder);
    }
}
