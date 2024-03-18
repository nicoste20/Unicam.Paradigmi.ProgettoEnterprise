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


        public int IdPresenza { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string? IdAlunno { get; set; }

        public virtual Utente? PresenzaAlunno { get; set; } //TODO:SONO DA METTERE?
    }
}
