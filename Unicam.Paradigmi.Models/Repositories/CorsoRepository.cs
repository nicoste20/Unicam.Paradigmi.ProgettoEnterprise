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
    public class CorsoRepository : GenericRepository<Corso>
    {

        public CorsoRepository(MyDbContext ctx) : base(ctx)
        {
        }
    }
}
