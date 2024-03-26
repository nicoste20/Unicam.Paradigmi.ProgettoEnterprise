using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class CalendarioDto
    {
        //mappa entità
        public CalendarioDto() { }

        public CalendarioDto(Lezione lezione)
        {
            IdCalendario = lezione.IdCalendario;
            IdCorso= lezione.IdCorso;
            DataOraInizio= lezione.DataOraInizio;
            DataOraFine= lezione.DataOraFine;
            Luogo = lezione.Luogo;
            Modalita = lezione.Modalita;
        }

        public int IdCalendario { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo { get; set; }
        public ModalitaErogazione Modalita { get; set; }
    }
}
