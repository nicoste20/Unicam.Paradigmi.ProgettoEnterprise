using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class SearchPresenzeResponse
    {
        public List<PresenzaDto> Presenze { get; set; } = new List<PresenzaDto>();

        public int NumeroPagine { get; set; }
    }
}
