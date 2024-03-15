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
    public class CalendarioConfiguration : IEntityTypeConfiguration<Calendario>
    {
        public void Configure(EntityTypeBuilder<Calendario> builder)
        {
            builder.ToTable("Calendari");
            builder.HasKey(k => k.IdCalendario);


            builder.Property(p => p.Modalita)
                .HasColumnName("Modalita")
                .HasConversion<int>();

            builder.HasOne(c => c.Corso)
                .WithMany(c => c.CalendarioLezioni)
                .HasForeignKey(c => c.IdCalendario);
        }
    }
}
