using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Utente
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Password { get; set; }

        public ICollection<Corso> Corsi { get; set; } = null!;
        public ICollection<Presenza> Presenze { get; set; } = null!;
    }
}
