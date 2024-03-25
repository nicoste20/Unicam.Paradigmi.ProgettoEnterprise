using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Calendario
    {
        public int IdCalendario { get; set; }
        public int IdCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo {  get; set; }
        public ModalitaErogazione Modalita {  get; set; }
        
        public Corso Corso { get; set; } = null!;
    }
}
