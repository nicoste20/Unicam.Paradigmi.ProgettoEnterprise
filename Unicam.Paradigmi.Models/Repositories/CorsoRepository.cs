using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    public class CorsoRepository : GenericRepository<Corso>
    {

        public CorsoRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public List<Corso> GetCoursesByFilter(string courseName = null, string lecturer = null, DateTime? lessonDate = null, int page = 1, int pageSize = 10)
        {
            var query = _ctx.Calendari.AsQueryable();

            return null;
        }


    }
}
