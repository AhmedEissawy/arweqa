using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;

namespace OA.Repo.Configurations
{
    public class LibraryTypeConfigurations : IEntityTypeConfiguration<LibraryType>
    {
        public void Configure(EntityTypeBuilder<LibraryType> entityBuilder)
        {
            entityBuilder.ToTable("tbl_LibraryType");
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Id).HasColumnName("pk_LibraryType_Id");
            entityBuilder.Property(p => p.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany(p => p.Libraries).WithOne(p => p.Category).HasForeignKey(p => p.CategoryCode).HasPrincipalKey(q => q.Category).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
