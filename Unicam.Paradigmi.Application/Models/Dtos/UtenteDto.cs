using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class UtenteDto
    {
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Password { get; set; }

    }
}
