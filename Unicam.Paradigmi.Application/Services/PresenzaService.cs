using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    // servizio per la gestione delle presenze, contiene i metodi per le chiamate web api con le loro logiche
    public class PresenzaService : IPresenzaService
    {
        private readonly PresenzaRepository _presenzaRepository;

        public PresenzaService(PresenzaRepository presenzaRepository)
        {
            _presenzaRepository = presenzaRepository;
        }

        // metodo per l'aggiunta di una presenza
        public async Task AddPresenzaAsync(Presenza presenza)
        {
            await _presenzaRepository.AggiungiAsync(presenza);
            await _presenzaRepository.SaveAsync();
        }

        // metodo per l'eliminazione di una presenza 
        public async Task DeleteAsync(int id)
        {
            var presenza = await _presenzaRepository.OttieniAsync(id);
            await _presenzaRepository.Elimina(presenza);
            await _presenzaRepository.SaveAsync();
        }

        // metodo per la ricerca di una presenza
        public async Task<(List<Presenza>, int)> Search(string courseName, string studentSurname,
            string lecturerSurname, DateTime? lessonDate, int page, int pageSize)
        {
            return await _presenzaRepository.GetPresencesByFilter(courseName, studentSurname, lecturerSurname, lessonDate, page,
                 pageSize);
        }

        // metodo per ottenere una presenza dato l'id
        public async Task<Presenza> GetPresenzaByIdAsync(int id)
        {
            return await _presenzaRepository.OttieniAsync(id);
        }
    }
}