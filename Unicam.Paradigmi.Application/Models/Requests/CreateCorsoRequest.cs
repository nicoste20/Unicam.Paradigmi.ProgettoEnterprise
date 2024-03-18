using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class CreateCorsoRequest
    {
        //mappa richiesta creazione corso
        public int IdDocente { get; set; }
        public string? NomeCorso { get; set; }
        public int NOre { get; set; }

        //mapping manuale
        public Corso ToEntity()
        {
            var corso = new Corso();
            corso.IdDocente = IdDocente;
            corso.NomeCorso = NomeCorso;
            corso.NOre = NOre;
            return corso;
        }
    }
}
