using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories;

public class PresenzaRepository : GenericRepository<Presenza>
{
    // repository per l'entità presenza
    public PresenzaRepository(MyDbContext ctx) : base(ctx)
    {
    }

    // ottiene le presenze tramite un filtro
    public async Task<(List<Presenza>, int)> GetPresencesByFilter(string courseName, string studentSurname, string lecturerSurname, DateTime? lessonDate, int page, int pageSize)
    {
        var query = _ctx.Presenze
            .Include(p => p.Lezione)
                .ThenInclude(l => l.Corso)
                .ThenInclude(c => c.Docente)
            .Include(p => p.Alunno)
            .AsQueryable();

        if (!string.IsNullOrEmpty(courseName))
        {
            query = query.Where(p => p.Lezione.Corso.NomeCorso == courseName);
        }

        if (!string.IsNullOrEmpty(studentSurname))
        {
            query = query.Where(p => p.Alunno.Cognome == studentSurname);
        }

        if (!string.IsNullOrEmpty(lecturerSurname))
        {
            query = query.Where(p => p.Lezione.Corso.Docente.Cognome == lecturerSurname);
        }

        if (lessonDate.HasValue)
        {
            DateTime startDate = lessonDate.Value.Date;
            query = query.Where(p => p.Lezione.DataOraInizio.Date == startDate);
        }

        int totalNum = await query.CountAsync();

        var presences = await query
            .OrderBy(p => p.Lezione.DataOraInizio) // Ordina per data di lezione, se necessario
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (presences, totalNum);
    }


}