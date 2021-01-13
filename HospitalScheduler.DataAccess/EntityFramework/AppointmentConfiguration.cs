using HospitalScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.DataAccess
{
    class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey("Id");

            builder
               .HasOne(b => b.Medic)
               .WithMany(m => m.AppointmentsAsMedic)
               .IsRequired();

            builder
                .HasOne(b => b.Patient)
                .WithMany(m => m.AppointmentsAsPatient)
                .IsRequired();

            builder
                .Property(b => b.AppointmentDate)
                .IsRequired();

            builder
                .HasOne(b => b.Room)
                .WithMany(r => r.Appointments);

            builder
                .HasMany(b => b.Documents)
                .WithOne(d => d.Appointment)
                .HasForeignKey(d => d.AppointmentId);

            builder
                .Property(b => b.TypeId)
                .IsRequired();

            builder
                .Property(b => b.StatusId)
                .IsRequired();

            builder
                .Property(b => b.Details)
                .IsRequired();

            builder
                .Property(b => b.Duration)
                .IsRequired();
        }
    }
}
