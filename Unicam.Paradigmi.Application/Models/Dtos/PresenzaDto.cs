using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    // DTO per una presenza
    public class PresenzaDto
    {
        public PresenzaDto() { }

        public PresenzaDto(Presenza presenza)
        {
            IdPresenza = presenza.IdPresenza;
            IdAlunno = presenza.IdAlunno;
            IdLezione = presenza.IdLezione;
            DataOraInizio = presenza.DataOraInizio;
            DataOraFine = presenza.DataOraFine;
        }

        public int IdPresenza { get; set; }
        public int IdAlunno { get; set; }
        public int IdLezione { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
    }
}
