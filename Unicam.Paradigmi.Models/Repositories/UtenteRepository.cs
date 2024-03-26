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
        //email fornita non vuota o nulla
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("L'email non può essere vuota o nulla", nameof(email));
        }

        // Query per ottenere l'utente corrispondente all'email fornita
        var user = _ctx.Utenti.FirstOrDefault(x => x.Email == email);

        //utente non trovato
        if (user == null)
        {
            throw new InvalidOperationException("Nessun utente trovato con l'email specificata.");
        }

        // Restituisci l'utente trovato
        return user;

    }

    public Utente GetUserByEmailPassword(string email, string password)
    {
        var utente = GetUserByEmail(email);
        if (utente != null && utente.Password.Equals(password))
        {
            return utente;
        }
        return null;
    }
   
}