using GenericSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Mappings
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TB_ORDER");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ORD_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Name)
               .HasColumnName("ORD_NAME")
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnName("ORD_DATE")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnName("ORD_STATUS")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
