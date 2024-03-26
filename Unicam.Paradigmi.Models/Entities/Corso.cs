using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Corso
    {
        public int IdCorso { get; set; }
        public int IdDocente { get; set; }
        public string NomeCorso { get; set; }
        public int NOre { get; set; }

        public Utente Docente {  get; set; } = null!;
        public ICollection<Lezione> CalendarioLezioni { get; set; } = null!;
    }
}
