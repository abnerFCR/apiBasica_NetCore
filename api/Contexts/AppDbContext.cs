using api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { 
        
        }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<Detalle> Detalle { get; set; }

        public DbSet<EstadoFactura> EstadoFactura { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalle>()
                .HasKey(c => new { c.idProducto, c.idFactura });
        }

    }
}
