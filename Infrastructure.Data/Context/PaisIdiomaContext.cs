using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class PaisIdiomaContext : DbContext
    {
        public PaisIdiomaContext(DbContextOptions<PaisIdiomaContext> options)
            : base(options)
        {
        }

        public DbSet<PaisEntity> Paises { get; set; }

        public DbSet<IdiomaEntity> Idiomas { get; set; }
    }
}
