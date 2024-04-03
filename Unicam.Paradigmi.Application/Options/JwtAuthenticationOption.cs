namespace Unicam.Paradigmi.Application.Options
{
    //la classe contiene le opzioni per l'autenticazione JWT
    public class JwtAuthenticationOption
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
