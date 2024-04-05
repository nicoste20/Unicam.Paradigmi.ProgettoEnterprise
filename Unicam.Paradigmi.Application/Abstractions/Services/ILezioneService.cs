using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{

    public interface ILezioneService
    {
        Task AddLezioneAsync(Lezione lezione);
        Task<Lezione> GetLezioneByIdAsync(int id);
    }
}
