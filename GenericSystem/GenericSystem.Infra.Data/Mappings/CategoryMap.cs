using GenericSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Mappings
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("TB_CATEGORY");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CAT_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Name)
               .HasColumnName("CAT_NAME")
               .HasColumnType("varchar(max)")
               .IsRequired();
        }
    }
}
