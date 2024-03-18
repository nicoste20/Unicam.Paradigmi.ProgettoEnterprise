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

        public CalendarioDto(Calendario calendario)
        {
            IdCalendario = calendario.IdCalendario;
            IdCorso= calendario.IdCorso;
            DataOraInizio= calendario.DataOraInizio;
            DataOraFine= calendario.DataOraFine;
            Luogo = calendario.Luogo;
            Modalita = calendario.Modalita;
        }

        public int IdCalendario { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string? Luogo { get; set; }
        public ModalitaErogazione Modalita { get; set; }
    }
}
