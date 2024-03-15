using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Utente
    {
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Corso>? Corsi { get; set; }
        public virtual ICollection<Presenza>? Presenze { get; set; }
    }
}
