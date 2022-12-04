using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class LessonAttachmentConfigurations : IEntityTypeConfiguration<LessonAttachment>
    {
        public void Configure(EntityTypeBuilder<LessonAttachment> entityBuilder)
        {
            entityBuilder.ToTable("tbl_LessonAttachment");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_LessonAttachment_Id");
            entityBuilder.Property(p => p.LessonId).HasColumnName("fk_Lesson_LessonAttachment_LessonId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Lesson>(p => p.Lesson).WithMany(p => p.LessonAttachments).HasForeignKey(p => p.LessonId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
