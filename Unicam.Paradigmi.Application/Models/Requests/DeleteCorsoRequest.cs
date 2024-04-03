using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    // richiesta per l'eliminazione di un corso
    public class DeleteCorsoRequest
    {
        public int IdCorso { get; set; }
    }
}
