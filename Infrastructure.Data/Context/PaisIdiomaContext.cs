using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Context.Configurations;

namespace Infrastructure.Data.Context
{
    public class PaisIdiomaContext : DbContext
    {
        public PaisIdiomaContext(DbContextOptions<PaisIdiomaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IdiomaEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PaisEntity> Paises { get; set; }

        public DbSet<IdiomaEntity> Idiomas { get; set; }
    }
}
