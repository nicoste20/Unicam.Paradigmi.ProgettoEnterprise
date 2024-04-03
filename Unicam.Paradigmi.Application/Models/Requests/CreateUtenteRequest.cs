using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    // richiesta per la creazione di un nuovo utente
    public class CreateUtenteRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //mapping manuale
        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.Email = this.Email;
            utente.Nome = this.Nome;
            utente.Cognome= this.Cognome;
            utente.Password = this.Password;
            return utente;
        }
    }
}
