using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPAzure.Models;

namespace TPAzure.Data
{
    public class TPAzureContext : DbContext
    {
        public TPAzureContext (DbContextOptions<TPAzureContext> options)
            : base(options)
        {
        }

        public DbSet<TPAzure.Models.PaisEntity> PaisEntity { get; set; }

        public DbSet<TPAzure.Models.IdiomaEntity> IdiomaEntity { get; set; }
    }
}
