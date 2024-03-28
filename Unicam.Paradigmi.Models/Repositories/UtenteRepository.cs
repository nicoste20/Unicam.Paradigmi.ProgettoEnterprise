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

    public Utente GetUserByEmail(string email)
    {
        return _ctx.Utenti.Where(x => x.Email == email.ToLower()).FirstOrDefault();
    }

    public Utente GetUserByEmailAndPassword(string email, string password)
    {
        var utente = GetUserByEmail(email);
        if (utente != null && utente.Password.Equals(password))
        {
            return utente;
        }
        return null;
    }

   
}