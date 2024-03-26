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
        public int IdAlunno { get; set; }
        public int IdLezione { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine {  get; set; }

        public Utente Alunno { get; set; } = null!;
        public Lezione Lezione { get; set; } = null!;
    }
}
