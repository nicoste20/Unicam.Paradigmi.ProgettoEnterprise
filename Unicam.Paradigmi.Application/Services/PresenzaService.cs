using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services;

public class PresenzaService : IPresenzaService
{
    private readonly PresenzaRepository _presenzaRepository;

    public PresenzaService(PresenzaRepository presenzaRepository)
    {
        _presenzaRepository = presenzaRepository;
    }

    public async Task<bool> AddPresenzaAsync(Presenza presenza)
    {
        await _presenzaRepository.AggiungiAsync(presenza);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var presenza = await _presenzaRepository.OttieniAsync(id);
        await _presenzaRepository.Elimina(presenza);
        return true;
    }

    public async Task<(List<Presenza>, int)> Search(string courseName, string studentSurname = null, string lecturerSurname = null,
        DateTime? lessonDate = null, int page = 1, int pageSize = 10)
    {
        return await _presenzaRepository.GetPresencesByFilter(courseName, studentSurname, lecturerSurname, lessonDate, page,
             pageSize);
    }
}