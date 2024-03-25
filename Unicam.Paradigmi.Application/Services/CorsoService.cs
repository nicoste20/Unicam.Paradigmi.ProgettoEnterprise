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
        public List<Corso> GetCorso()
        {
            return new List<Corso>();
        }

        public void AddCorso(Corso corso)
        {
            _corsoRepository.Aggiungi(corso);
            _corsoRepository.Save();
        }
    }
}
