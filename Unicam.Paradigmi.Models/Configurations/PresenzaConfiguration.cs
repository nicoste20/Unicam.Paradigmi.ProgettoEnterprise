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
    // configurazione di mapping per l'entità presenza
    public class PresenzaConfiguration : IEntityTypeConfiguration<Presenza>
    {
        public void Configure(EntityTypeBuilder<Presenza> builder)
        {
            // tabella di destinazione
            builder.ToTable("Presenze");

            //chiave primaria
            builder.HasKey(k => k.IdPresenza);
        }
    }
}
