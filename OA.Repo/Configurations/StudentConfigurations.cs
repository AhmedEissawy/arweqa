using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Student");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Student_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany(p => p.Answers).WithOne(p => p.Student).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(p => p.Requests).WithOne(p => p.Student).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne(a => a.User).WithOne(b => b.Student).HasForeignKey<Student>(b => b.Id).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(a => a.ExtraRequests).WithOne(b => b.Student).HasForeignKey(b => b.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(a => a.StudentLessonQuestionAnswers).WithOne(b => b.Student).HasForeignKey(b => b.StudentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}