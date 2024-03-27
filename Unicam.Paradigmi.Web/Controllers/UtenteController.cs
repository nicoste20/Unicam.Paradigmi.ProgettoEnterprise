using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("CreaUtente")]
        public IActionResult Create(CreateUtenteRequest request) {

            if(_utenteService.GetUserByEmail(request.Email) != null)
            {
                return BadRequest(ResponseFactory.WithError("Utente non aggiunto, email già presente nel sistema"));
            }

            var utente = request.ToEntity();
            _utenteService.AddUtente(utente);

            var response = new CreateUtenteResponse();
            response.utente = new UtenteDto(utente);
            return Ok(ResponseFactory.WithSuccess(response));
            

        }
    }
}
