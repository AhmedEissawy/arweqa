using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class StudentlessonQuestionAnswerConfigurations : IEntityTypeConfiguration<StudentLessonQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentLessonQuestionAnswer> entityBuilder)
        {
            entityBuilder.ToTable("tbl_StudentlessonQuestionAnswer");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_StudentlessonQuestionAnswer_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Student>(p => p.Student).WithMany(p => p.StudentLessonQuestionAnswers).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<LessonQuestionAnswer>(a => a.LessonQuestionAnswer).WithMany(b => b.StudentLessonQuestionAnswers).HasForeignKey(b => b.LessonQuestionAnswerId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<LessonQuestion>(a => a.LessonQuestion).WithMany(b => b.StudentLessonQuestionAnswers).HasForeignKey(b => b.LessonQuestionId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
