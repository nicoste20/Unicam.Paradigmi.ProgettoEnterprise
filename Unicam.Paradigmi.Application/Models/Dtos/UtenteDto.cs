using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    // DTO per un utente
    public class UtenteDto
    {
        public UtenteDto() { }

        public UtenteDto(Utente utente)
        {
            Email = utente.Email;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Password = utente.Password;
        }

        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
