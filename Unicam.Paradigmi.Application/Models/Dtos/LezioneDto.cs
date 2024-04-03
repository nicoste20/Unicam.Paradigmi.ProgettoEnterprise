using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    // DTO per una lezione
    public class LezioneDto
    {
        public LezioneDto() { }

        public LezioneDto(Lezione lezione)
        {
            IdLezione = lezione.IdLezione;
            IdCorso= lezione.IdCorso;
            DataOraInizio= lezione.DataOraInizio;
            DataOraFine= lezione.DataOraFine;
            Luogo = lezione.Luogo;
            Modalita = lezione.Modalita;
        }

        public int IdLezione { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo { get; set; }
        public ModalitaErogazione Modalita { get; set; }
    }
}
