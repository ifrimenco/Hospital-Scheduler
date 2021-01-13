using HospitalScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalScheduler.DataAccess
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey("Id");

            builder
                .Property(b => b.Name)
                .HasMaxLength(50);

            builder.HasMany(r => r.Appointments)
                .WithOne(a => a.Room)
                .HasForeignKey(a => a.RoomId);
        }
    }
}
