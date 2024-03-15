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
    public class PresenzaConfiguration : IEntityTypeConfiguration<Presenza>
    {
        public void Configure(EntityTypeBuilder<Presenza> builder)
        {
            builder.ToTable("Presenze");
            builder.HasKey(k => k.IdPresenza);

            // uno-a-molti con Alunno
            builder.HasOne(o => o.PresenzaAlunno)
                .WithMany(o => o.Presenze)
                .HasForeignKey(o => o.IdAlunno);
        }
    }
}
