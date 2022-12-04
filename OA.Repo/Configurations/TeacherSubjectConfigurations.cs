using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class TeacherSubjectConfigurations : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> entityBuilder)
        {
            entityBuilder.ToTable("tbl_TeacherSubject");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_TeacherSubject_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.Property(p => p.TeacherId).HasColumnName("fk_Teacher_TeacherSubject_TeacherId").IsRequired();
            entityBuilder.Property(p => p.SubjectId).HasColumnName("fk_Subject_TeacherSubject_SubjectId").IsRequired();
            entityBuilder.HasOne<Teacher>(p => p.Teacher).WithMany(p => p.TeacherSubjects).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<SubjectGrade>(p => p.Subject).WithMany(p => p.TeacherSubjects).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany(p => p.SubjectPermessions).WithOne(p => p.TeacherSubject).HasForeignKey(p => p.Teacher_Subject_Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
