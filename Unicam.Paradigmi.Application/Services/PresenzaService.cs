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

    public bool AddPresenza(Presenza presenza)
    {
        _presenzaRepository.Aggiungi(presenza);
        return true;
    }

    public bool Delete(int id)
    {
        _presenzaRepository.Elimina(id);
        return true;
    }

    public List<Presenza> Search(string courseName, out int totalNum, string studentSurname = null, string lecturerSurname = null, 
        DateTime? lessonDate = null, int page = 1, int pageSize = 10)
    {
       return _presenzaRepository.GetPresencesByFilter(courseName, out totalNum, studentSurname, lecturerSurname, lessonDate, page,
            pageSize);
    }
}