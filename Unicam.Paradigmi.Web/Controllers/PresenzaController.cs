using Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Privacy;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PresenzaController : ControllerBase
    {
        private readonly IPresenzaService _presenzaService;
        private readonly IUtenteService _utenteService;
        private readonly ILezioneService _lezioneService;

        public PresenzaController(IPresenzaService presenzaService, IUtenteService utenteService, ILezioneService lezioneService)
        {
            _presenzaService = presenzaService;
            _utenteService = utenteService;
            _lezioneService = lezioneService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreatePresenza(CreatePresenzaRequest request )
        {
            var presenza = request.ToEntity();
            presenza.IdAlunno = _utenteService.GetUserByEmail(request.EmailAlunno).IdUtente;

            if (_utenteService.GetUserById(presenza.IdAlunno)!=null && _lezioneService.GetLezioneById(presenza.IdLezione) != null)
            {
                var presenzaValida = ControllaLezione(presenza.IdLezione, presenza.DataOraInizio, presenza.DataOraFine);
                if (presenzaValida)
                {
                    _presenzaService.AddPresenza(presenza);
                   
                    var response = new CreatePresenzaResponse();
                    response.Presenza = new PresenzaDto(presenza);
                    return Ok(ResponseFactory.WithSuccess(response));
                }
                else
                {
                    return BadRequest(ResponseFactory.WithError("Presenza nulla per la lezione richiesta"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Presenza nulla"));
            }
        }


        [HttpDelete]
        [Route("delete")]
        public IActionResult DeletePresenza(DeletePresenzaRequest request)
        {
            _presenzaService.Delete(request.IdPresenza);
            return Ok(ResponseFactory.WithSuccess("Presenza Eliminata"));
        }

        private bool ControllaLezione(int idLezione, DateTime inizioPresenza, DateTime finePresenza)
        {
            var lezione = _lezioneService.GetLezioneById(idLezione);
            if(lezione != null)
            {
                if (inizioPresenza >= lezione.DataOraInizio && finePresenza <= lezione.DataOraFine)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
