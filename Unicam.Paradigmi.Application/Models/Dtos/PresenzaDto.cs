using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class PresenzaDto
    {
        public PresenzaDto() { }

        public PresenzaDto(Presenza presenza)
        {
            IdPresenza = presenza.IdPresenza;
            DataOraInizio = presenza.DataOraInizio;
            DataOraFine = presenza.DataOraFine;
            IdAlunno = presenza.IdAlunno;
            PresenzaAlunno = presenza.Alunno;
        }

        public int IdPresenza { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string IdAlunno { get; set; }

        public Utente PresenzaAlunno { get; set; } //TODO:SONO DA METTERE?
    }
}
