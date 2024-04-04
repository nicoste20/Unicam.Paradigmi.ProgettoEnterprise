namespace Unicam.Paradigmi.Application.Models.Requests;

// richiesta per la ricerca di una presenza
public class SearchPresenzeRequest
{
    public string? NomeCorso { get; set; } = string.Empty;
    public string? CognomeStudente { get; set; } = null;
    public string? CognomeDocente { get; set; } = null;
    public DateTime? DataLezione { get; set; } = null;
    public int Pagina { get; set; }
    public int DimensionePagina { get; set; }
}