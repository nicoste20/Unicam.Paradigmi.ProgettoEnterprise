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

        public async Task AddLezioneAsync(Lezione lezione)
        {
            await _lezioneRepository.AggiungiAsync(lezione);
            await _lezioneRepository.SaveAsync();
        }

        public async Task<Lezione> GetLezioneByIdAsync(int id)
        {
            return await _lezioneRepository.OttieniAsync(id);
        }
    }
}
