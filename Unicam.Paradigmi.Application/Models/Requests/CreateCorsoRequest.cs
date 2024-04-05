using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    // richiesta per la creazione di un nuovo corso
    public class CreateCorsoRequest
    {
        public string NomeCorso { get; set; } = string.Empty;
        public int NOre { get; set; }

        //mapping manuale
        public Corso ToEntity()
        {
            var corso = new Corso();
            corso.NomeCorso = NomeCorso;
            corso.NOre = NOre;
            return corso;
        }
    }
}
