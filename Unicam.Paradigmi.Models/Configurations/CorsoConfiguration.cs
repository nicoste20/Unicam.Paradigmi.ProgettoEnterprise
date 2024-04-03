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
    // configurazione di mapping per l'entità corso
    public class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
            // tabella di destinazione
            builder.ToTable("Corsi");

            //chiave primaria
            builder.HasKey(c => c.IdCorso);

            //relazione uno-a-molti tra Corso e Lezione
            builder.HasMany(c => c.CalendarioLezioni)
                .WithOne(l => l.Corso)
                .HasForeignKey(l => l.IdCorso);
        }
    }
}
