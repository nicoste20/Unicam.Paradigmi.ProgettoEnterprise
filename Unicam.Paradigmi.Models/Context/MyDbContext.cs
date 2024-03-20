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
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        //DbSet per le varie classi
        public DbSet<Corso> Corsi { get; set; }

        public DbSet<Calendario> Calendari { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder) //metodo invocato automaticamente quando istanziamo EF
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); //applica tutte le configurazioni che trovi in assembly che prendi dove sta il contesto

            base.OnModelCreating(modelBuilder);
        }

    }
}
