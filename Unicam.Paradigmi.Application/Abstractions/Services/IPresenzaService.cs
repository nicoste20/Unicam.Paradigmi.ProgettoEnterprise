using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services;

public interface IPresenzaService
{
    public bool AddPresenza(Presenza presenza);

    public bool RemovePresenza(int id);
}