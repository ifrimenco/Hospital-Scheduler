using HospitalScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalScheduler.DataAccess
{
    class ProfilePictureConfiguration : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {
            builder.ToTable("ProfilePictures");
            builder.HasKey("Id");

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);

            builder
                .Property(b => b.File)
                .IsRequired();
        }
    }
}
