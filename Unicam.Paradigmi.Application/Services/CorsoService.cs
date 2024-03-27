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
        public Corso GetCorso(int id)
        {
            return _corsoRepository.Ottieni(id);
        }

        public void AddCorso(Corso corso)
        {
            _corsoRepository.Aggiungi(corso);
            _corsoRepository.Save();
        }

        public void Delete(int id)
        {
            _corsoRepository.Elimina(id);
            _corsoRepository.Save();
        }
    }
}
