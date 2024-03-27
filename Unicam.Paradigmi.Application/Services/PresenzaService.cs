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

    public bool RemovePresenza(int id)
    {
        _presenzaRepository.Elimina(id);
        return true;
    }
}