using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class LessonConfigurations : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Lesson");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Lesson_Id");
            entityBuilder.Property(p => p.UnitId).HasColumnName("fk_Unit_Lesson_UnitId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.Unit).WithMany(p => p.Lessons).HasForeignKey(p => p.UnitId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(p => p.LessonAttachments).WithOne(p => p.Lesson).HasForeignKey(p => p.LessonId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(a => a.LessonQuestions).WithOne(b => b.Lesson).HasForeignKey(b => b.LessonId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
