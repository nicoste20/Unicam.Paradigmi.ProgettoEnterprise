
namespace Unicam.Paradigmi.Application.Models.Requests
{
    // richiesta per la creazione di un nuovo token
    public class CreateTokenRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
