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
    // configurazione di mapping per l'entità lezione
    public class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            // tabella di destinazione
            builder.ToTable("Lezioni");

            //chiave primaria
            builder.HasKey(k => k.IdLezione);

            // proprietà gestita con enumerazione e salvata nel db tramite un dato di tipo tinyint
            builder.Property(p => p.Modalita)
               .HasColumnName("Modalita")
               .HasColumnType("tinyint");

            // relazione uno-a-molti tra Presenze e Lezione
            builder.HasMany(l => l.Presenze)
                 .WithOne(p => p.Lezione)
                 .HasForeignKey(p => p.IdLezione);

        }
    }
}
