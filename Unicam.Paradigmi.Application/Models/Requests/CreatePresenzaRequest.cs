using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests;

// richiesta per la creazione di una nuova presenza
public class CreatePresenzaRequest
{
    public string EmailAlunno { get; set; }
    public int IdLezione { get; set; }
    public DateTime DataOraInizio { get; set; } 
    public DateTime DataOraFine { get; set; }

    //mapping manuale
    public Presenza ToEntity()
    {
        var presenza = new Presenza();
        presenza.IdLezione = IdLezione;
        presenza.DataOraInizio = DataOraInizio;
        presenza.DataOraFine = DataOraFine;
        return presenza;
    }

}