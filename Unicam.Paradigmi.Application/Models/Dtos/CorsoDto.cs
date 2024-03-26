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

        public CorsoDto() { }   
        public CorsoDto(Corso corso)
        {
            IdCorso = corso.IdCorso;
            IdDocente = corso.IdDocente;
            NomeCorso = corso.NomeCorso;
            NOre = corso.NOre;
            Docenti = corso.Docenti;
            CalendarioLezioni = corso.CalendarioLezioni;
        }


        public int IdCorso { get; set; }
        public int IdDocente { get; set; }
        public string NomeCorso { get; set; }
        public int NOre { get; set; }
        public ICollection<Utente> Docenti { get; set; }
        public ICollection<Lezione> CalendarioLezioni { get; set; }

    }
}
