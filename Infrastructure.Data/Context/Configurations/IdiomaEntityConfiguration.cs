using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class IdiomaEntityConfiguration : IEntityTypeConfiguration<IdiomaEntity>
    {
        public void Configure(EntityTypeBuilder<IdiomaEntity> builder)
        {
            builder
                .HasOne(x => x.Pais)
                .WithMany(x => x.Idiomas);
        }
    }
}
