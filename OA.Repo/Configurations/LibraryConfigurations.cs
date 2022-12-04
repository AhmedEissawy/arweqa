using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class LibraryConfigurations : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Library");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Library_Id");
            entityBuilder.Property(p => p.GradeId).HasColumnName("fk_Grade_Library_GradeId").IsRequired();
            entityBuilder.Property(p => p.SemesterId).HasColumnName("fk_Semester_Library_SemesterId").IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.Property(p => p.IsPremium).HasDefaultValue(true);
            entityBuilder.HasOne<LibraryType>(p => p.Category).WithMany(p => p.Libraries).HasForeignKey(p => p.CategoryCode).HasPrincipalKey(q => q.Category).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Grade>(p => p.Grade).WithMany(p => p.Libraries).HasForeignKey(p => p.GradeId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne<Semester>(p => p.Semester).WithMany(p => p.Libraries).HasForeignKey(p => p.SemesterId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
