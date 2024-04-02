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
    public class CorsoService : ICorsoService
    {
        private readonly CorsoRepository _corsoRepository;

        public CorsoService(CorsoRepository corsoRepository)
        {
            _corsoRepository = corsoRepository;
        }


        //metodi per le chiamate web api con le loro logiche
        public async Task<Corso> GetCorsoAsync(int id)
        {
            return await _corsoRepository.OttieniAsync(id);
        }

        public async Task AddCorsoAsync(Corso corso)
        {
            await _corsoRepository.AggiungiAsync(corso);
            await _corsoRepository.SaveAsync();
        }

        public async Task<bool> DeleteAsync(Corso corso)
        {
            await _corsoRepository.Elimina(corso);
            await _corsoRepository.SaveAsync();
            return true;
        }
    }
}
