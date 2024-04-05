using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services;

public interface IPresenzaService
{
    Task AddPresenzaAsync(Presenza presenza);
    Task DeleteAsync(int idPresenza);

    Task<Presenza> GetPresenzaByIdAsync(int id);
    public Task<(List<Presenza>, int)> Search(string courseName, string studentSurname,
        string lecturerSurname, DateTime? lessonDate, int page, int pageSize);
}