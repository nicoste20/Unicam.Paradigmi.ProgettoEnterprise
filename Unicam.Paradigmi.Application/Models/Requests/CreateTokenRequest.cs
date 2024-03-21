using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class CreateTokenRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
