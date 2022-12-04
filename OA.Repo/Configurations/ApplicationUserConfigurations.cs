using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne<Section>(p => p.Section).WithMany(p => p.Users).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.MessageReceivers).WithOne(p => p.ReceiverIdentity).HasForeignKey(p => p.ReceiverIdentityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.MessageSenders).WithOne(p => p.SenderIdentity).HasForeignKey(p => p.SenderIdentityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Grade>(p => p.Grade).WithMany(p => p.Users).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Student>(a => a.Student).WithOne(b => b.User).HasForeignKey<Student>(b => b.Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Teacher>(a => a.Teacher).WithOne(b => b.User).HasForeignKey<Teacher>(b => b.Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Notifications).WithOne(q => q.User).HasForeignKey(q => q.StudentIdentityId);
        }
    }
}
