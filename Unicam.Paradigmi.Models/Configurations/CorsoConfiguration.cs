using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Configurations
{
    public class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
            builder.ToTable("Corsi");

            builder.HasKey(c => c.IdCorso);


            builder.HasOne(c => c.Docente)
                .WithMany(d => d.CorsiCreati)
                .HasForeignKey(c => c.IdDocente);

            builder.HasMany(c => c.CalendarioLezioni)
                .WithOne(l => l.Corso)
                .HasForeignKey(l => l.IdCorso);
        }
    }
}
