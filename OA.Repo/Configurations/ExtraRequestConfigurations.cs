using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class ExtraRequestConfigurations : IEntityTypeConfiguration<ExtraRequest>
    {
        public void Configure(EntityTypeBuilder<ExtraRequest> entityBuilder)
        {
            entityBuilder.ToTable("tbl_ExtraRequest");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_ExtraRequest_Id");
            entityBuilder.Property(p => p.StudentId).HasColumnName("fk_Student_ExtraRequest_StudentId").IsRequired();
            entityBuilder.Property(p => p.SubjectId).HasColumnName("fk_Subject_ExtraRequest_SubjectId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Student>(p => p.Student).WithMany(p => p.ExtraRequests).HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<SubjectGrade>(p => p.Subject).WithMany(p => p.ExtraRequests).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
