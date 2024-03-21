using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public  class CorsoDto
    {
        public int IdCorso { get; set; }
        public int IdDocente { get; set; }
        public string? NomeCorso { get; set; }
        public int NOre { get; set; }
        public virtual ICollection<Utente>? Docenti { get; set; }
        public virtual ICollection<Calendario>? CalendarioLezioni { get; set; }

    }
}
