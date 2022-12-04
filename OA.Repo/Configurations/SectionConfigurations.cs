using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;


namespace OA.Repo.Configurations
{
    public class SectionConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Section");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Section_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
           // entityBuilder.HasMany(p => p.SubjectGrades).WithOne(p => p.Section).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<ApplicationUser>(p => p.Users).WithOne(p => p.Section).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasMany<Student>(p => p.Students).WithOne(p => p.Section).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
