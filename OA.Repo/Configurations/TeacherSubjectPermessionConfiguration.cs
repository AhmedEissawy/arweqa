using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;
namespace OA.Repo.Configurations
{
    public class TeacherSubjectPermessionConfiguration : IEntityTypeConfiguration<TeacherSubjectPermession>
    {
        public void Configure(EntityTypeBuilder<TeacherSubjectPermession> builder)
        {
            builder.HasKey(a => new { a.Id, a.Teacher_Subject_Id });
            builder.ToTable("tbl_TeacherSubjectPermessions");
            builder.HasOne(a => a.TeacherSubject).WithMany(a => a.SubjectPermessions).HasForeignKey(a => a.Teacher_Subject_Id).IsRequired();
        }
    }
}
