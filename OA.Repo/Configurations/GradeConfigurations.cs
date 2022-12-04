using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class GradeConfigurations : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Grade");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Grade_Id");
            entityBuilder.Property(p => p.StageId).HasColumnName("fk_Stage_Grade_StageId").IsRequired();
            entityBuilder.Property(p => p.GradeName).IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<Stage>(p => p.Stage).WithMany(p => p.Grades).HasForeignKey(p => p.StageId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<ApplicationUser>(p => p.Users).WithOne(p => p.Grade).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<SubjectGrade>(p => p.SubjectGrades).WithOne(p => p.Grade).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Library>(p => p.Libraries).WithOne(p => p.Grade).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Student>(p => p.Students).WithOne(p => p.Grade).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
