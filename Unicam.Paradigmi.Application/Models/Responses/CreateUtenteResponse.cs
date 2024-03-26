using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class CreateUtenteResponse
    {
        public CreateUtenteResponse()
        {
        }

        public CreateUtenteResponse(UtenteDto utente) {
            this.utente = utente;
        }

        public UtenteDto utente { get; set; } = null!;
    }
}
