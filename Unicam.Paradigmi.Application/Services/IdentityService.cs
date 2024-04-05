using System;
using System.Linq;
using System.Security.Claims;
using Unicam.Paradigmi.Application.Abstractions.Services;

namespace Unicam.Paradigmi.Application.Services
{
    //Servizio per ottenere informazioni dell'utente corrente dal JWT
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

            if (userIdentity == null || !userIdentity.Claims.Any())
            {
                throw new InvalidOperationException("Utente non è disponibile");
            }

            var idClaim = userIdentity.Claims.FirstOrDefault(c => c.Type == "Id");

            if (idClaim == null)
            {
                throw new InvalidOperationException("Utente non è disponibile.");
            }

            if (!int.TryParse(idClaim.Value, out int userId))
            {
                throw new InvalidOperationException("Errore nella restituzione dell'utente");
            }

            return userId;
        }
    }
}