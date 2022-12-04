using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class RequestAttachmentConfigurations : IEntityTypeConfiguration<RequestAttachment>
    {
        public void Configure(EntityTypeBuilder<RequestAttachment> entityBuilder)
        {
            entityBuilder.ToTable("tbl_RequestAttachment");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_RequestAttachment_Id");
            entityBuilder.Property(p => p.RequestId).HasColumnName("pk_Request_RequestAttachment_RequestId").IsRequired();
            entityBuilder.Property(p => p.File).IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Request>(p => p.Request).WithMany(p => p.RequestFiles).HasForeignKey(p => p.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
