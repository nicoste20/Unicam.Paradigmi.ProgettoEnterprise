using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests;

public class CreatePresenzaRequest
{
    public string EmailAlunno { get; set; }
    public int IdLezione { get; set; }
    public DateTime DataOraInizio { get; set; } 
    public DateTime DataOraFine { get; set; }

    //TODO:sono da mettere?
   // public Utente Alunno { get; set; } = null!;
   // public Lezione Lezione { get; set; } = null!;

    public Presenza ToEntity()
    {
        var presenza = new Presenza();
        presenza.IdLezione = IdLezione;
        presenza.DataOraInizio = DataOraInizio;
        presenza.DataOraFine = DataOraFine;
        return presenza;
    }

}