namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    //Interfaccia che contiene la definizione del metodo per la creazione di un token
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(string mail, string password);
    }
}
