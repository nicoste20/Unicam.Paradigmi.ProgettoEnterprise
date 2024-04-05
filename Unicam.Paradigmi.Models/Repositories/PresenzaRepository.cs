using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories;

public class PresenzaRepository : GenericRepository<Presenza>
{

    public PresenzaRepository(MyDbContext ctx) : base(ctx)
    {
    }

    //Ricerca delle presenze tramite filtri
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
            string courseNameLower = courseName.ToLower();
            query = query.Where(p => p.Lezione.Corso.NomeCorso.ToLower() == courseNameLower);
        }

        if (!string.IsNullOrEmpty(studentSurname))
        {
            string studentSurnameLower = studentSurname.ToLower();
            query = query.Where(p => p.Alunno.Cognome.ToLower() == studentSurnameLower);
        }

        if (!string.IsNullOrEmpty(lecturerSurname))
        {
            string lecturerSurnameLower = lecturerSurname.ToLower();
            query = query.Where(p => p.Lezione.Corso.Docente.Cognome.ToLower() == lecturerSurnameLower);
        }

        if (lessonDate.HasValue)
        {
            DateTime startDate = lessonDate.Value.Date;
            query = query.Where(p => p.Lezione.DataOraInizio.Date == startDate);
        }

        int totalNum = await query.CountAsync();

        var presences = await query
            .OrderBy(p => p.Lezione.DataOraInizio) // Ordina per data di lezione
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (presences, totalNum);
    }


}