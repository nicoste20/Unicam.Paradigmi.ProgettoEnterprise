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
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(k => k.IdUtente);

            // uno-a-molti con Presenze
            builder.HasMany(u => u.Presenze)
               .WithOne(p => p.Alunno)
               .HasForeignKey(p => p.IdAlunno);

            builder.HasMany(u => u.CorsiCreati)
                .WithOne(c => c.Docente)
                .HasForeignKey(c => c.IdDocente);


        }
    }
}
