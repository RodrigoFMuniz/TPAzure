using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class PaisEntityConfiguration : IEntityTypeConfiguration<PaisEntity>
    {
        public void Configure(EntityTypeBuilder<PaisEntity> builder)
        {
            builder
               .HasMany(x => x.Idiomas)
               .WithOne(x => x.Pais);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(100);
        }
    }
}
