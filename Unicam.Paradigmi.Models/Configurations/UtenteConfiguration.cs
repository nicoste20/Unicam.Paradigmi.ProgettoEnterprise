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
    // configurazione di mapping per l'entità utente
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            // tabella di destinazione
            builder.ToTable("Utenti");

            //chiave primaria
            builder.HasKey(k => k.IdUtente);

            // relazione uno-a-molti tra Alunno e Presenze
            builder.HasMany(u => u.Presenze)
               .WithOne(p => p.Alunno)
               .HasForeignKey(p => p.IdAlunno);

            // relazione uno-a-molti tra Docente e Corsi
            builder.HasMany(u => u.CorsiCreati)
                .WithOne(c => c.Docente)
                .HasForeignKey(c => c.IdDocente);
        }
    }
}
