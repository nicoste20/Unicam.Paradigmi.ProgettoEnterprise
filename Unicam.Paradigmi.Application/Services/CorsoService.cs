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
    // servizio per la gestione dei corsi, contiene i metodi per le chiamate web api con le loro logiche
    public class CorsoService : ICorsoService
    {
        private readonly CorsoRepository _corsoRepository;

        public CorsoService(CorsoRepository corsoRepository)
        {
            _corsoRepository = corsoRepository;
        }

        // metodo per ottenere un corso dal repository tramite ID
        public async Task<Corso> GetCorsoAsync(int id)
        {
            return await _corsoRepository.OttieniAsync(id);
        }

        // metodo per l'aggiunta di un nuovo corso
        public async Task AddCorsoAsync(Corso corso)
        {
            await _corsoRepository.AggiungiAsync(corso);
            await _corsoRepository.SaveAsync();
        }

        // metodo per eliminare un corso
        public async Task DeleteAsync(Corso corso)
        {
            await _corsoRepository.Elimina(corso);
            await _corsoRepository.SaveAsync();
        }

        //metodo per ottenere un corso dato il nome
        public async Task<bool> ExistCorsoByNameAsync(string nomeCorso)
        {
            return await _corsoRepository.ExistCorsoByNameAsync(nomeCorso);
        }
    }
}
