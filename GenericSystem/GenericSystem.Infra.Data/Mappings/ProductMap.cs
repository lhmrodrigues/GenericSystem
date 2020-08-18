using GenericSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Mappings
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("PROD_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Name)
               .HasColumnName("PROD_NAME")
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(c => c.Photo)
                .HasColumnName("PROD_PHOTO")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnName("PROD_PRICE")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(c => c.IdCategory)
                .HasColumnName("CAT_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(f => f.IdCategory);
        }
    }
}
