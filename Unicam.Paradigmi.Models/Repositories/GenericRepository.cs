using Unicam.Paradigmi.Models.Context;

namespace Unicam.Paradigmi.Models.Repositories
{
    // classe astratta che definisce le operazioni di base per una repository generica
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        // aggiunge un'entità al contesto del database
        public async Task AggiungiAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
        }

        // ottiene un'entità dal contesto del database
        public async Task<T> OttieniAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        // elimina un'entità dal contesto del database
        public async Task Elimina(T id)
        {
             _ctx.Set<T>().Remove(id);
        }

        // salva un'entità al contesto del database
        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
