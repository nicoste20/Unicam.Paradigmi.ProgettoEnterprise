using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;

namespace Unicam.Paradigmi.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AggiungiAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
        }

        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> OttieniAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }
        public async Task Elimina(object id)
        {
            var entity = await OttieniAsync(id);
             _ctx.Entry(entity).State = EntityState.Deleted;
        }
        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
