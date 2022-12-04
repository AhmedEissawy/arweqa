using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class BranchConfigurations : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entityBuilder)
        {
            entityBuilder.HasKey(G => G.Id);
            entityBuilder.Property(G => G.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany<Student>(G => G.Students).WithOne(G => G.Branch).HasForeignKey(G => G.BranchId).OnDelete(DeleteBehavior.NoAction);
        }
    
    }
}
