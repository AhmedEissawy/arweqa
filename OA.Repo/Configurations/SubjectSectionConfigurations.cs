using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class SubjectSectionConfigurations : IEntityTypeConfiguration<SubjectSection>
    {
        public void Configure(EntityTypeBuilder<SubjectSection> entityBuilder)
        {
            entityBuilder.Ignore(p => p.Id);
            entityBuilder.HasKey(a => new { a.SubjectGradeId, a.SectionId });
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.Section).WithMany(p => p.SubjectSections).HasForeignKey(p => p.SectionId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne(p => p.SubjectGrade).WithMany(p => p.SubjectSections).HasForeignKey(p => p.SubjectGradeId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}