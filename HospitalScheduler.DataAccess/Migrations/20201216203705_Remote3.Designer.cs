﻿// <auto-generated />
using System;
using HospitalScheduler.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalScheduler.DataAccess.Migrations
{
    [DbContext(typeof(HospitalSchedulerContext))]
    [Migration("20201216203705_Remote3")]
    partial class Remote3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospitalScheduler.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Conclusions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MedicId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<byte>("StatusId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("TypeId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Female"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Male"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Other"
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.ProfilePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medic"
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 103,
                            Name = "Not Set"
                        },
                        new
                        {
                            Id = 2,
                            Name = "000"
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Generalist"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cardiologist"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Otorhinolaryngologist - ORL"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dentist"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dermatologist"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Endocrinologist"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Gynecologist"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Immunologist"
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CNP = "",
                            Email = "ifrimenco.alex@gmail.com",
                            FirstName = "Admin",
                            GenderId = 3,
                            LastName = "",
                            PasswordHash = "RR18KlgNgNnZ2wya2rU0Gc0tw/6AlloHN+jItlDIne2s3n5FFDJXgdjMclBMOQGC"
                        },
                        new
                        {
                            Id = 100,
                            CNP = "Confidential",
                            Email = "Confidential",
                            FirstName = "Confidential",
                            GenderId = 3,
                            LastName = "",
                            PasswordHash = "rzmX+3UkF2bGgy/3m1zf32saY+fbB6yzYjZQlmXQcrh/Kxodi2ApGrnjedH7x0mQ"
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Appointment", b =>
                {
                    b.HasOne("HospitalScheduler.Entities.User", "Medic")
                        .WithMany("AppointmentsAsMedic")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalScheduler.Entities.User", "Patient")
                        .WithMany("AppointmentsAsPatient")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HospitalScheduler.Entities.Room", "Room")
                        .WithMany("Appointments")
                        .HasForeignKey("RoomId");

                    b.Navigation("Medic");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Document", b =>
                {
                    b.HasOne("HospitalScheduler.Entities.Appointment", "Appointment")
                        .WithMany("Documents")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.ProfilePicture", b =>
                {
                    b.HasOne("HospitalScheduler.Entities.User", "User")
                        .WithOne("ProfilePicture")
                        .HasForeignKey("HospitalScheduler.Entities.ProfilePicture", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.User", b =>
                {
                    b.HasOne("HospitalScheduler.Entities.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalScheduler.Entities.Specialization", "Specialization")
                        .WithMany("Medics")
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Gender");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.UserRole", b =>
                {
                    b.HasOne("HospitalScheduler.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalScheduler.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Appointment", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Room", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.Specialization", b =>
                {
                    b.Navigation("Medics");
                });

            modelBuilder.Entity("HospitalScheduler.Entities.User", b =>
                {
                    b.Navigation("AppointmentsAsMedic");

                    b.Navigation("AppointmentsAsPatient");

                    b.Navigation("ProfilePicture");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
