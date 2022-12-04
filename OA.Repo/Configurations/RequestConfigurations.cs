using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class RequestConfigurations : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Request");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Request_Id");
            entityBuilder.Property(p => p.SubjectId).HasColumnName("fk_Subject_Request_SubjectId").IsRequired();
            entityBuilder.Property(p => p.StudentId).HasColumnName("fk_Student_Request_StudentId").IsRequired();
            entityBuilder.Property(p => p.TeacherId).HasColumnName("fk_Teacher_Request_TeacherId").IsRequired();
            entityBuilder.Property(p => p.Replied).HasDefaultValue(false);
            entityBuilder.Property(p => p.RepliedInTime).HasDefaultValue(false);
            entityBuilder.Property(p => p.Deleted).HasDefaultValue(false);
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<SubjectGrade>(p => p.Subject).WithMany(p => p.Requests).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Student>(p => p.Student).WithMany(p => p.Requests).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Teacher>(p => p.Teacher).WithMany(p => p.Requests).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Answer>(p => p.Answers).WithOne(p => p.Request).HasForeignKey(p => p.RequestId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<RequestAttachment>(p => p.RequestFiles).WithOne(p => p.Request).HasForeignKey(p => p.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
