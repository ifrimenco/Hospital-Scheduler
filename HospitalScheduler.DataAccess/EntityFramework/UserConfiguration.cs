using HospitalScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalScheduler.DataAccess
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey("Id");

            builder
                .Property(b => b.FirstName)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(b => b.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(b => b.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(b => b.CNP)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(b => b.PasswordHash)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            builder
                .HasOne(u => u.Specialization)
                .WithMany(ur => ur.Medics);

            builder
                .HasMany(u => u.AppointmentsAsMedic)
                .WithOne(a => a.Medic)
                .HasForeignKey(a => a.MedicId);

            builder
                .HasMany(u => u.AppointmentsAsPatient)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(u => u.ProfilePicture)
                .WithOne(p => p.User)
                .HasForeignKey<ProfilePicture>(u => u.UserId);
            builder
                .Property(b => b.GenderId)
                .IsRequired();
        }
    }
}
