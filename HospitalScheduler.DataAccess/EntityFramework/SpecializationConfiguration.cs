using HospitalScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.DataAccess
{
    class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>

    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("Specializations");

            builder.HasKey("Id");

            builder
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(b => b.Medics)
                .WithOne(m => m.Specialization)
                .HasForeignKey(m => m.SpecializationId);
        }
    }
}
