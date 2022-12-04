using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class AnswerAttachmentConfigurations : IEntityTypeConfiguration<AnswerAttachment>
    {
        public void Configure(EntityTypeBuilder<AnswerAttachment> entityBuilder)
        {
            entityBuilder.ToTable("tbl_AnswerAttachment");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_AnswerAttachment_Id");
            entityBuilder.Property(p => p.AnswerId).HasColumnName("fk_Answer_AnswerAttachment_AnswerId").IsRequired();
            entityBuilder.Property(p => p.File).IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Answer>(p => p.Answer).WithMany(p => p.AnswerFiles).HasForeignKey(p => p.AnswerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
