using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    // repository per l'entità corso
    public class CorsoRepository : GenericRepository<Corso>
    {
        public CorsoRepository(MyDbContext ctx) : base(ctx)
        {
        }

        // verifica se esiste un corso con il nome specificato
        public async Task<bool> ExistCorsoByNameAsync(string nomeCorso)
        {
            var corso = _ctx.Corsi.Where(c => c.NomeCorso == nomeCorso).FirstOrDefaultAsync();
            if(corso.Result != null )
            {
                return true;
            }
            return false;
        }
    }
}
