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


            // Definizione della relazione many-to-many con Utente (Docenti)
            builder.HasMany(c => c.Docenti)
                .WithMany(u => u.Corsi)
                .UsingEntity(j => j.ToTable("CorsiDocenti"));

            // Configurazione della relazione uno-a-molti con Calendario
            builder.HasMany(c => c.CalendarioLezioni)
                .WithOne(cal => cal.Corso)
                .HasForeignKey(cal => cal.IdCorso);
        }
    }
}
