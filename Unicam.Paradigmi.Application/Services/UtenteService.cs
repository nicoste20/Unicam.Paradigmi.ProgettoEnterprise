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

        public Utente GetUserByEmail(string email)
        {
            return _utenteRepository.GetUserByEmail(email);
        }

        public bool AddUtente(Utente utente)
        {
            if(_utenteRepository.GetUserByEmail(utente.Email) != null)
            {
                _utenteRepository.Save();
                return true;
            }
            return false;
        }

        public Utente GetUserByEmailAndPassword(string email, string password)
        {
            return _utenteRepository.GetUserByEmailPassword(email, password);
        }
    }
}
