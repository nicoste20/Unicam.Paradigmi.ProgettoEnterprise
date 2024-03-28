using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services;

public interface IPresenzaService
{
    public bool AddPresenza(Presenza presenza);
    bool Delete(int idPresenza);

    public List<Presenza> Search(string courseName, out int totalNum, string studentSurname = null, string lecturerSurname = null,
        DateTime? lessonDate = null, int page = 1, int pageSize = 10);
}