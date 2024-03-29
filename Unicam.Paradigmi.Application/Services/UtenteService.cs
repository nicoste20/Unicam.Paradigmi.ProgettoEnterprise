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
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteService(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public async Task AddUtenteAsync(Utente utente)
        {
            await _utenteRepository.AggiungiAsync(utente);
            await _utenteRepository.SaveAsync();
        }

        public async Task<Utente> GetUserByEmailAsync(string email)
        {
            return await _utenteRepository.GetUserByEmailAsync(email);
        }

        public async Task<Utente> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _utenteRepository.GetUserByEmailAndPasswordAsync(email, password);
        }

        public async Task<Utente> GetUserByIdAsync(int id)
        {
            return await _utenteRepository.OttieniAsync(id);
        }
    }
}
