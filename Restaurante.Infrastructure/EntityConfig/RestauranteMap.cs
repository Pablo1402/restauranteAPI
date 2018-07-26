using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.EntityConfig
{
    public class RestauranteMap : IEntityTypeConfiguration<restaurante>
    {
        public void Configure(EntityTypeBuilder<restaurante> builder)
        {
            builder.HasKey(r => r.id);

            builder.HasMany(c => c.pratos)
                .WithOne(c => c.restaurante)
                .HasForeignKey(c => c.restaurante_id)
                .HasPrincipalKey(c => c.id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.nome).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
