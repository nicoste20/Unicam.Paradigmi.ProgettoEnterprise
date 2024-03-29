using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        return await _ctx.Utenti.Where(x => x.Email == email.ToLower()).FirstOrDefaultAsync();
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