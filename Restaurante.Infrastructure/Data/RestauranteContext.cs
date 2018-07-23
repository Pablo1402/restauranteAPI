using Microsoft.EntityFrameworkCore;
using Restaurante.ApplicationCore.Entity;
using Restaurante.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {

        }

        public DbSet<prato> pratos { get; set; }
        public DbSet<restaurante> restaurantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<prato>().ToTable("prato");
            modelBuilder.Entity<restaurante>().ToTable("restaurante");

            modelBuilder.ApplyConfiguration(new RestauranteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());

            //modelBuilder.Entity<restaurante>().Property(e => e.nome).HasColumnType("varchar(200)").IsRequired();
            //modelBuilder.Entity<prato>().Property(e => e.nome).HasColumnType("varchar(200)").IsRequired();
            //modelBuilder.Entity<prato>().Property(e => e.preco).HasColumnType("decimal(9,2)").IsRequired();




            //base.OnModelCreating(modelBuilder);
        }

    }
}
