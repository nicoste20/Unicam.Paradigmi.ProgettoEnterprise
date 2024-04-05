using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories;

public class UtenteRepository : GenericRepository<Utente>
{

    public UtenteRepository(MyDbContext ctx) : base(ctx)
    {
    }

    public async Task<Utente> GetUserByEmailAsync(string email)
    {
        return await _ctx.Utenti.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<Utente> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        var utente = await GetUserByEmailAsync(email);
        if (utente != null && utente.Password.Equals(password))
        {
            return utente;
        }
        return null;
    }   
}