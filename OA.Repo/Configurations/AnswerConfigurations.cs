using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class AnswerConfigurations : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Answer");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Answer_Id");
            entityBuilder.Property(p => p.TeacherId).HasColumnName("fk_Teacher_Answer_TeacherId").IsRequired();
            entityBuilder.Property(p => p.StudentId).HasColumnName("fk_Student_Answer_StudentId").IsRequired();
            entityBuilder.Property(p => p.SubjectId).HasColumnName("fk_Subject_Answer_SubjectId").IsRequired();
            entityBuilder.Property(p => p.RequestId).HasColumnName("fk_Request_Answer_RequestId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Teacher>(p => p.Teacher).WithMany(p => p.Answers).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Student>(p => p.Student).WithMany(p => p.Answers).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<SubjectGrade>(p => p.Subject).WithMany(p => p.Answers).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Request>(p => p.Request).WithMany(p => p.Answers).HasForeignKey(p => p.RequestId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<AnswerAttachment>(p => p.AnswerFiles).WithOne(p => p.Answer).HasForeignKey(p => p.AnswerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
