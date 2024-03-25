using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface ICorsoService
    {
        List<Corso> GetCorso();
        void AddCorso(Corso corso);
    }
}
