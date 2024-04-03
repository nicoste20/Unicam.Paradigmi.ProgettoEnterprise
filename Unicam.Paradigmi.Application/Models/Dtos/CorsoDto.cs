using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    // DTO per un corso
    public class CorsoDto
    {
        public CorsoDto() { }   
        public CorsoDto(Corso corso)
        {
            IdCorso = corso.IdCorso;
            IdDocente = corso.IdDocente;
            NomeCorso = corso.NomeCorso;
            NOre = corso.NOre;
            Docente = corso.Docente;
            CalendariLezioni = corso.CalendarioLezioni;
        }


        public int IdCorso { get; set; }
        public int IdDocente { get; set; }
        public string NomeCorso { get; set; }
        public int NOre { get; set; }
        public Utente Docente { get; set; }
        public ICollection<Lezione> CalendariLezioni { get; set; }

    }
}
