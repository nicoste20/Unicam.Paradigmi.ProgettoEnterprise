using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    // servizio per la gestione degli utenti, contiene i metodi per le chiamate web api con le loro logiche
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        // metodo per l'aggiunta di un utente
        public async Task AddUtenteAsync(Utente utente)
        {
            await _utenteRepository.AggiungiAsync(utente);
            await _utenteRepository.SaveAsync();
        }

        // metodo per ottenere un utente data l'email
        public async Task<Utente> GetUserByEmailAsync(string email)
        {
            return await _utenteRepository.GetUserByEmailAsync(email);
        }

        //metodo per otterenere un utente data mail e password
        public async Task<Utente> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _utenteRepository.GetUserByEmailAndPasswordAsync(email, password);
        }

        //metodo per ottenere un utente dato l'id
        public async Task<Utente> GetUserByIdAsync(int id)
        {
            return await _utenteRepository.OttieniAsync(id);
        }
    }
}
