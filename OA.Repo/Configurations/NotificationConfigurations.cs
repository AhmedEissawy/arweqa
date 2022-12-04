using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Notification");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Notification_Id");
            entityBuilder.Property(p => p.StudentIdentityId).HasColumnName("fk_ApplicationUser_Notification_ApplicationUserId").IsRequired();
            entityBuilder.Property(p => p.Seen).HasDefaultValue(false);
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.User).WithMany(q => q.Notifications).HasForeignKey(q => q.StudentIdentityId);
        }
    }
}
