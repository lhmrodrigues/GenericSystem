using GenericSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USERS");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("USER_ID")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.Nome)
               .HasColumnName("USER_NAME")
               .HasColumnType("varchar(MAX)")
               .IsRequired();

            builder.Property(x => x.CPF)
                .HasColumnName("USER_CPF")
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnName("USER_DATE")
                .HasColumnType("datetime")
                .IsRequired();

        }
    }
}
