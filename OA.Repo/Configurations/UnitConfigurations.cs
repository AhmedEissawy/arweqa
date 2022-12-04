using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class UnitConfigurations : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Unit");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Unit_Id");
            entityBuilder.Property(p => p.SubjectId).HasColumnName("fk_Subject_Unit_SubjectId").IsRequired();
            entityBuilder.Property(p => p.SemesterId).HasColumnName("fk_Semester_Unit_SemesterId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne<SubjectGrade>(p => p.Subject).WithMany(p => p.Units).HasForeignKey(p => p.SubjectId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Semester>(p => p.Semester).WithMany(p => p.Units).HasForeignKey(p => p.SemesterId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Lesson>(p => p.Lessons).WithOne(p => p.Unit).HasForeignKey(p => p.UnitId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}