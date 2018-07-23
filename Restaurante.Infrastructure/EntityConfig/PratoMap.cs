using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.EntityConfig
{
    public class PratoMap : IEntityTypeConfiguration<prato>
    {
        public void Configure(EntityTypeBuilder<prato> builder)
        {
            builder.HasKey(p => p.id);
            builder.HasOne(p => p.restaurante)
                .WithMany(p => p.pratos)
                .HasForeignKey(p => p.restaurante_id)
                .HasPrincipalKey(p => p.id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.preco).HasColumnType("decimal(9,2)").IsRequired();
        }
    }
}
