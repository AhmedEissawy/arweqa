using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;


namespace OA.Repo.Configurations
{
    public class LessonVideoRoomConfiguration : IEntityTypeConfiguration<LessonVideoRoom>
    {
        public void Configure(EntityTypeBuilder<LessonVideoRoom> builder)
        {
            builder.ToTable("tbl_LessonVideoRoom");
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Lesson).WithMany(a => a.Rooms).HasForeignKey(a => a.LessonId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.Connections).WithOne(a => a.LessonVideoRoom).HasForeignKey(a => a.Room_Id).OnDelete(DeleteBehavior.NoAction);
                builder.HasIndex(a => new { a.RoomId, a.Deleted }).IsUnique();
        }
    }

    public class LessonVideoRoomConnectionsConfiguration : IEntityTypeConfiguration<LessonVideoRoomConnections>
    {
        public void Configure(EntityTypeBuilder<LessonVideoRoomConnections> builder)
        {
            builder.HasKey(a => new { a.Connection_Id, a.Room_Id });
            builder.Ignore(a => a.Id);
            builder.Ignore(a => a.Deleted);
            builder.Ignore(a => a.IsActive);
            builder.HasOne(a => a.LessonVideoRoom).WithMany(a => a.Connections).HasForeignKey(a => a.Room_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
