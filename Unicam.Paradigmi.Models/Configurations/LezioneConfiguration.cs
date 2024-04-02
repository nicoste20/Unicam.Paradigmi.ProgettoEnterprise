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
    public class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("Lezioni");
            builder.HasKey(k => k.IdLezione);


            builder.Property(p => p.Modalita)
               .HasColumnName("Modalita")
               .HasColumnType("tinyint");


            builder.HasMany(l => l.Presenze)
                 .WithOne(p => p.Lezione)
                 .HasForeignKey(p => p.IdLezione);

        }
    }
}
