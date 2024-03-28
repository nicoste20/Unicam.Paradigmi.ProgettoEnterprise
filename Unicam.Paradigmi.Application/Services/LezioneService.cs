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
    public class LezioneService : ILezioneService
    {
        private readonly LezioneRepository _lezioneRepository;

        public LezioneService(LezioneRepository lezioneRepository)
        {
            _lezioneRepository = lezioneRepository;
        }

        public void AddLezione(Lezione lezione)
        {
            _lezioneRepository.Aggiungi(lezione);
            _lezioneRepository.Save();
        }

        public Lezione GetLezioneById(int id)
        {
            return _lezioneRepository.Ottieni(id);
        }
    }
}
