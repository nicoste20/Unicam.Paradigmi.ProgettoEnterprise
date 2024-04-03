using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    //interfaccia per la classe TokenService, contiene la definizione del metodo per la creazione di un token
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(string mail, string password);
    }
}
