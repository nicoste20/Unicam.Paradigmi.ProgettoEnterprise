using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services;

//interfaccia per la classe PresenzaService, contiene la definizione dei metodi per l'aggiunta di una nuova presenza,
//l'eliminazione di una presenza, il metodo che restituise una presenza dato l'id e il metodo che ne restituisce
//le presenze di un corso
public interface IPresenzaService
{
    Task AddPresenzaAsync(Presenza presenza);
    Task DeleteAsync(int idPresenza);

    Task<Presenza> GetPresenzaByIdAsync(int id);
    public Task<(List<Presenza>, int)> Search(string courseName, string studentSurname,
        string lecturerSurname, DateTime? lessonDate, int page, int pageSize);
}