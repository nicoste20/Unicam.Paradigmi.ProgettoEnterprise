using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        Utente GetUserByEmail(string email);
        bool VerifyPassword(Utente user, string password);
        bool AddUtente(Utente utente);
    }
}
