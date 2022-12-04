using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class SemesterConfigurations : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Semester");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Semester_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany<Unit>(p => p.Units).WithOne(p => p.Semester).HasForeignKey(p => p.SemesterId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Library>(p => p.Libraries).WithOne(p => p.Semester).HasForeignKey(p => p.SemesterId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
