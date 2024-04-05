using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface ICorsoService
    {
        Task AddCorsoAsync(Corso corso);
        Task<Corso> GetCorsoAsync(int id);
        Task DeleteAsync(Corso corso);
        Task<bool> ExistCorsoByNameAsync(string nomeCorso);
    }
}
