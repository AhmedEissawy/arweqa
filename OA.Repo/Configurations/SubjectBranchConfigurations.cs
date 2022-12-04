using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class SubjectBranchConfigurations : IEntityTypeConfiguration<SubjectBranch>
    {
        public void Configure(EntityTypeBuilder<SubjectBranch> entityBuilder)
        {
            entityBuilder.Ignore(p => p.Id);
            entityBuilder.HasKey(a => new { a.SubjectGradeId, a.BranchId });
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasOne(p => p.Branch).WithMany(p => p.SubjectBranches).HasForeignKey(p => p.BranchId).OnDelete(DeleteBehavior.NoAction);
            entityBuilder.HasOne(p => p.SubjectGrade).WithMany(p => p.SubjectBranches).HasForeignKey(p => p.SubjectGradeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}