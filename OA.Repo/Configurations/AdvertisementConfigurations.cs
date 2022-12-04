using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class AdvertisementConfigurations : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {

        }
    }
}