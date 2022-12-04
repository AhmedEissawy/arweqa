using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class MessageConfigurations : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Message");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Message_Id");
            entityBuilder.Property(p => p.SenderIdentityId).HasColumnName("fk_ApplicationUser_Message_ApplicationUserSenderId").IsRequired();
            entityBuilder.Property(p => p.ReceiverIdentityId).HasColumnName("fk_ApplicationUser_Message_ApplicationUserReceiverId").IsRequired();
            entityBuilder.Property(p => p.IsAdmin).HasDefaultValue(false);
            entityBuilder.Property(p => p.IsTeacher).HasDefaultValue(false);
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.ReceiverIdentity).WithMany(q => q.MessageReceivers).HasForeignKey(q => q.ReceiverIdentityId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne(p => p.SenderIdentity).WithMany(q => q.MessageSenders).HasForeignKey(q => q.SenderIdentityId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
