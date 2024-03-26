using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    public class Utente
    {
        public int IdUtente { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Password { get; set; }

        public ICollection<Presenza> Presenze { get; set; } = null!;
        public ICollection<Corso> CorsiCreati { get; set; } = null!;
    }
}
