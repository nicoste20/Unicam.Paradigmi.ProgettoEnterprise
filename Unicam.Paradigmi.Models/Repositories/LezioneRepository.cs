using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    public class LezioneRepository : GenericRepository<Lezione>
    {

        public LezioneRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public async Task<Lezione> OttieniAsync(int id)
        {
            return await _ctx.Lezioni.Where(l => l.IdLezione == id).FirstOrDefaultAsync();
        }
    }
}
