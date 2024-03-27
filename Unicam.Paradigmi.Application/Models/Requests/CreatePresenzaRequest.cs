using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests;

public class CreatePresenzaRequest
{
    public int IdAlunno { get; set; }
    public int IdLezione { get; set; }
    public DateTime DataOraInizio { get; set; } = DateTime.Now;
    public DateTime DataOraFine { get; set; } = DateTime.MaxValue;

    public Presenza ToEntity()
    {
        var presenza = new Presenza();
        presenza.IdLezione = IdLezione;
        presenza.IdAlunno = IdAlunno;
        presenza.DataOraInizio = DataOraInizio;
        presenza.DataOraFine = DataOraFine;
        return presenza;
    }

}