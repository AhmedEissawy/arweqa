using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class StageConfigurations : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> entityBuilder)
        {
            entityBuilder.ToTable("tbl_Stage");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_Stage_Id");
            entityBuilder.Property(p => p.StageName).IsRequired();
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany<Grade>(p => p.Grades).WithOne(p => p.Stage).HasForeignKey(p => p.StageId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
