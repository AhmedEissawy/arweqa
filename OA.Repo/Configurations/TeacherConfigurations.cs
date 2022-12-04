using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Teacher");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Teacher_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany<Answer>(p => p.Answers).WithOne(p => p.Teacher).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Request>(p => p.Requests).WithOne(p => p.Teacher).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<TeacherSubject>(p => p.TeacherSubjects).WithOne(p => p.Teacher).HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<ApplicationUser>(a => a.User).WithOne(b => b.Teacher).HasForeignKey<Teacher>(b => b.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
