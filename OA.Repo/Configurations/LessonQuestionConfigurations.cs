using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class LessonQuestionConfigurations : IEntityTypeConfiguration<LessonQuestion>
    {
        public void Configure(EntityTypeBuilder<LessonQuestion> entityBuilder)
        {
            entityBuilder.ToTable("tbl_LessonQuestion");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_LessonQuestion_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Lesson>(a => a.Lesson).WithMany(b => b.LessonQuestions).HasForeignKey(b => b.LessonId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<LessonQuestionAnswer>(a => a.LessonQuestionAnswers).WithOne(b => b.LessonQuestion).HasForeignKey(b => b.LessonQuestionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(a => a.StudentLessonQuestionAnswers).WithOne(b => b.LessonQuestion).HasForeignKey(b => b.LessonQuestionId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
