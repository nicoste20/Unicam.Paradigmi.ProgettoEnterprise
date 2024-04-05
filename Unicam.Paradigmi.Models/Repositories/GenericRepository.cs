using Unicam.Paradigmi.Models.Context;

namespace Unicam.Paradigmi.Models.Repositories
{
    //Classe astratta che definisce le operazioni di base per una repository
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

        public async Task<T> OttieniAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task Elimina(T id)
        {
             _ctx.Set<T>().Remove(id);
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
