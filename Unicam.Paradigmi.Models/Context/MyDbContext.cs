using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        //DbSet per le varie classi
        public DbSet<Corso> Corsi { get; set; }

        public DbSet<Lezione> Lezioni { get; set; }

        public DbSet<Presenza> Presenze { get; set; }

        public DbSet<Utente> Utenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("data source=localhost;Initial catalog=Paradigmi_Progetto;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True");

            }
        }

        //Metodo invocato automaticamente quando istanziamo EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Applica tutte le configurazioni che trovi in assembly
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
