using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories;

public class PresenzaRepository : GenericRepository<Presenza>
{

    public PresenzaRepository(MyDbContext ctx) : base(ctx)
    {
    }

    public List<Presenza> GetPresencesByFilter(string courseName, string studentSurname = null, string lecturerSurname = null, DateTime? lessonDate = null, int page = 1, int pageSize = 10)
    {
        var query = _ctx.Presenze.AsQueryable();

        query = query.Include(p => p.Lezione)
            .ThenInclude(l => l.Corso).Where(p => p.Lezione.Corso.NomeCorso == courseName);

        if (!string.IsNullOrEmpty(studentSurname))
            query = query.Include(p => p.Alunno)
                .Where(p => p.Alunno.Cognome == studentSurname);

        if (!string.IsNullOrEmpty(lecturerSurname))
            query = query.Include(p => p.Lezione)
                .ThenInclude(l => l.Corso)
                .ThenInclude(c => c.Docente).Where(l => l.Lezione.Corso.Docente.Cognome == lecturerSurname);

        if (lessonDate.HasValue)
        {
            DateTime startDate = lessonDate.Value.Date;
            query = query.Include(p => p.Lezione)
                .Where(p => p.Lezione.DataOraFine.Date.Equals(startDate));
        }

        return query.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

}