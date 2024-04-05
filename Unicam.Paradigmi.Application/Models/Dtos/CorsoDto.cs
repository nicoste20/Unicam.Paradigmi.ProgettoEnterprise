using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{

    public class CorsoDto
    {
        public CorsoDto() { }   
        public CorsoDto(Corso corso)
        {
            IdCorso = corso.IdCorso;
            IdDocente = corso.IdDocente;
            NomeCorso = corso.NomeCorso;
            NOre = corso.NOre;
        }


        public int IdCorso { get; set; }
        public int IdDocente { get; set; }
        public string NomeCorso { get; set; }
        public int NOre { get; set; }

    }
}
