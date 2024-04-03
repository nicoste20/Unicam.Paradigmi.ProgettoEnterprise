using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    // servizio per la gestione delle lezioni, contiene i metodi per le chiamate web api con le loro logiche
    public class LezioneService : ILezioneService
    {
        private readonly LezioneRepository _lezioneRepository;

        public LezioneService(LezioneRepository lezioneRepository)
        {
            _lezioneRepository = lezioneRepository;
        }

        // metodo per l'aggiunta di una lezione
        public async Task AddLezioneAsync(Lezione lezione)
        {
            await _lezioneRepository.AggiungiAsync(lezione);
            await _lezioneRepository.SaveAsync();
        }

        // metodo per ottenere una lezione dato l'id
        public async Task<Lezione> GetLezioneByIdAsync(int id)
        {
            return await _lezioneRepository.OttieniAsync(id);
        }
    }
}
