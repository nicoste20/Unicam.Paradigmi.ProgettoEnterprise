using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Presenza
    {
        public int IdPresenza { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine {  get; set; }
        public string IdAlunno { get; set; }

       public Utente PresenzaAlunno { get; set; } = null!;
    }
}
