using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class UtenteDto
    {

        public UtenteDto() { }

        public UtenteDto(Utente utente)
        {
            Email = utente.Email;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
        }

        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
