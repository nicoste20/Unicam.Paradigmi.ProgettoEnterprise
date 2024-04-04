using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    //interfaccia per la classe CorsoService, contiene la definizione dei metodi per l'aggiunta di un nuovo corso,
    //l'eliminazione di uno presente, il metodo che ne restituisce uno dato l'id e il metodo che dato il nome di un corso
    //restituisce true se esiste nel db, false altrimenti
    public interface ICorsoService
    {
        Task AddCorsoAsync(Corso corso);
        Task<Corso> GetCorsoAsync(int id);
        Task DeleteAsync(Corso corso);
        Task<bool> ExistCorsoByNameAsync(string nomeCorso);
    }
}
