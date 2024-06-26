﻿namespace Unicam.Paradigmi.Models.Entities
{
    public class Lezione
    {
        public int IdLezione { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo {  get; set; }
        public ModalitaErogazione Modalita {  get; set; }
        
        public Corso Corso { get; set; } = null!;
        public ICollection<Presenza> Presenze { get; set; } = null!;
    }
}
