using HospitalScheduler.Common;
using HospitalScheduler.Entities;
using HospitalScheduler.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.DataAccess
{
    public class HospitalSchedulerContext : DbContext
    {

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public HospitalSchedulerContext(DbContextOptions<HospitalSchedulerContext> options)
            : base(options) 
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new ProfilePictureConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.Entity<Specialization>().HasData(
                //Generalist = 1,
                //Cardiologist = 2,
                //Neurologist = 3,
                //Otorhinolaryngologist = 4,
                //Dentist = 5,
                //Dermatologist = 6,
                //Endocrinologist = 7,
                //Gynecologist = 8,
                //Immunologist = 9,
                //FamilyDoctor = 10
                new Specialization
                {
                    Name = "Generalist",
                    Id = 1
                },
                new Specialization
                {
                    Name = "Cardiologist",
                    Id = 2
                },
                new Specialization
                {
                    Name = "Otorhinolaryngologist - ORL",
                    Id = 3
                },
                new Specialization
                {
                    Name = "Dentist",
                    Id = 4
                },
                new Specialization
                {
                    Name = "Dermatologist",
                    Id = 5
                },
                new Specialization
                {
                    Name = "Endocrinologist",
                    Id = 6
                },
                new Specialization
                {
                    Name = "Gynecologist",
                    Id = 7
                },
                new Specialization
                {
                    Name = "Immunologist",
                    Id = 8
                });

            // insert values into Roles table
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "Medic"
                });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 100,
                    Name = "Not Set"
                });

            // insert admin user into Users table 
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CNP = "",
                    Email = "ifrimenco.alex@gmail.com",
                    PasswordHash = HashHelper.HashPassword("123123"),
                    FirstName = "Admin",
                    LastName = "",
                    GenderId = 3,
                },
                new User
                {
                    Id = 2,
                    CNP = "Confidential",
                    Email = "Confidential",
                    PasswordHash = HashHelper.HashPassword("123123"),
                    FirstName = "Confidential",
                    LastName = "",
                    GenderId = 3
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 2
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 3
                }
                );

            // insert values into Gender table
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    Type = "Female"
                },
                new Gender
                {
                    Id = 2,
                    Type = "Male"
                },
                new Gender
                {
                    Id = 3,
                    Type = "Other"
                });

        }
    }
}
