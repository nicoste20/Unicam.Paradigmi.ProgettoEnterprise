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
        Task AddUtenteAsync(Utente utente);
        Task<Utente> GetUserByEmailAsync(string email);
        Task<Utente> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<Utente> GetUserByIdAsync(int id);
    }
}
