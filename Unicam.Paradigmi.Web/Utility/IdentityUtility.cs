using System.Security.Claims;

namespace Unicam.Paradigmi.Web.Utility
{
    public static class IdentityUtility
    {
        public static int GetUserIdentity(ClaimsIdentity? userIdentity)
        {
            if (userIdentity == null || !userIdentity.Claims.Any())
            {
                throw new ArgumentNullException(nameof(userIdentity), "Identità dell'utente non valida");
            }

            var idClaim = userIdentity.Claims.SingleOrDefault(c => c.Type == "Id");

            if (idClaim == null)
            {
                throw new InvalidOperationException("Claim 'Id' non trovato per l'utente.");
            }

            if (!int.TryParse(idClaim.Value, out int userId))
            {
                throw new InvalidOperationException("Errore nella restituzione dell'utente");
            }

            return userId;
        }
    }
}