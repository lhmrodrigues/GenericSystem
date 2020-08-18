using GenericSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Mappings
{
    internal class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("TB_REQUEST");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("REQ_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnName("REQ_DATE")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Quantity)
                .HasColumnName("REQ_QUANTITY")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(c => c.IdProduct)
                .HasColumnName("PROD_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.IdOrder)
                .HasColumnName("ORD_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(p => p.Product)
                   .WithMany()
                   .HasForeignKey(f => f.IdProduct);

            builder.HasOne(p => p.Order)
                   .WithMany()
                   .HasForeignKey(f => f.IdOrder);
        }
    }
}
