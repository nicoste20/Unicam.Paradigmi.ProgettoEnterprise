using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    public class CorsoRepository : GenericRepository<Corso>
    {
        public CorsoRepository(MyDbContext ctx) : base(ctx)
        {
        }

        // Verifica se esiste un corso con il nome specificato
        public async Task<bool> ExistCorsoByNameAsync(string nomeCorso)
        {
            var corso = _ctx.Corsi.Where(c => c.NomeCorso.ToLower() == nomeCorso.ToLower()).FirstOrDefaultAsync();
            return corso.Result != null;
        }
    }
}
