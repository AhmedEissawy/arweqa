using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class SubjectMzhbConfigurations : IEntityTypeConfiguration<SubjectMzhb>
    {
        public void Configure(EntityTypeBuilder<SubjectMzhb> entityBuilder)
        {
            entityBuilder.Ignore(p => p.Id);
            entityBuilder.HasKey(a => new {a.SubjectGradeId,a.MzhbId });
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.Mzhb).WithMany(p => p.SubjectMzhbs).HasForeignKey(p => p.MzhbId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne(p => p.SubjectGrade).WithMany(p => p.SubjectMzhbs).HasForeignKey(p => p.SubjectGradeId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
