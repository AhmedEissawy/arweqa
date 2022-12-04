using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class GovernorateConfigurations : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> entityBuilder)
        {
            entityBuilder.HasKey(G => G.Id);
            entityBuilder.Property(G => G.IsActive).HasDefaultValue(true);
            entityBuilder.HasMany<Student>(G => G.Students).WithOne(G => G.Governorate).HasForeignKey(G => G.GovernorateId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}