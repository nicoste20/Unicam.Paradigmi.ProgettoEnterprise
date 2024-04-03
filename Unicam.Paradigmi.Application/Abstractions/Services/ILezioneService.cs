using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    //interfaccia per la classe LezioneService, contiene la definizione dei metodi per l'aggiunta di una nuova lezione,
    //e il metodo che ne restituisce una dato l'id
    public interface ILezioneService
    {
        Task AddLezioneAsync(Lezione lezione);
        Task<Lezione> GetLezioneByIdAsync(int id);
    }
}
