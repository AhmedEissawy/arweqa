using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class lessonQuestionAnswerConfigurations : IEntityTypeConfiguration<LessonQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<LessonQuestionAnswer> entityBuilder)
        {
            entityBuilder.ToTable("tbl_lessonQuestionAnswer");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_lessonQuestionAnswer_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<LessonQuestion>(a => a.LessonQuestion).WithMany(b => b.LessonQuestionAnswers).HasForeignKey(b => b.LessonQuestionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<StudentLessonQuestionAnswer>(a => a.StudentLessonQuestionAnswers).WithOne(b => b.LessonQuestionAnswer).HasForeignKey(b => b.LessonQuestionAnswerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
