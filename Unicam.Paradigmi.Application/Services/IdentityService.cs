﻿using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Unicam.Paradigmi.Application.Abstractions.Services;

namespace Unicam.Paradigmi.Application.Services
{
    // servizio per la gestione delle identità degli utenti, contiene i metodi per le chiamate web api con le loro logiche
    internal class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // metodo per ottenere l'identità di un utente
        public int GetUserIdentity()
        {
            // Ottieni l'identità dell'utente dall'HttpContextAccessor
            var userIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            // Verifica se l'identità è nulla o se non contiene alcun claim
            if (userIdentity == null || !userIdentity.Claims.Any())
            {
                throw new InvalidOperationException("Utente non è disponibile");
            }

            // Trova il claim con il tipo "id"
            var idClaim = userIdentity.Claims.FirstOrDefault(c => c.Type == "Id");

            // Verifica se il claim è stato trovato
            if (idClaim == null)
            {
                throw new InvalidOperationException("Utente non è disponibile.");
            }

            // Converte il valore del claim in un intero
            if (!int.TryParse(idClaim.Value, out int userId))
            {
                throw new InvalidOperationException("Errore nella restituzione dell'utente");
            }

            return userId;
        }
    }
}