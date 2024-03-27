using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class CreateLezioneRequest
    {
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo { get; set; }
        public ModalitaErogazione Modalita { get; set; }

        public Lezione ToEntity()
        {
            var lezione = new Lezione();
            lezione.IdCorso = IdCorso;
            lezione.DataOraInizio = DataOraInizio;
            lezione.DataOraFine = DataOraFine;
            lezione.Luogo=Luogo;
            lezione.Modalita= Modalita; 
            return lezione;
        }
    }
}
