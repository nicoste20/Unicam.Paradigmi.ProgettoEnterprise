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

    //controller per la gestione delle presenze, necessita di autorizzazione
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

        //endpoint per la creazione di una nuova presenza
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreatePresenzaAsync(CreatePresenzaRequest request)
        {
            var presenza = request.ToEntity();

            //controllo che la mail dell'alunno sia presente nel db
            if(await _utenteService.GetUserByEmailAsync(request.EmailAlunno)==null)
            {
                return BadRequest(ResponseFactory.WithError("Email Alunno non presente"));
            }

            var alunno = await _utenteService.GetUserByEmailAsync(request.EmailAlunno);
            presenza.IdAlunno = alunno.IdUtente;
            var lezione = await _lezioneService.GetLezioneByIdAsync(presenza.IdLezione);

            //controllo che la lezione per cui si sta inserendo la lezione non sia nulla
            if (lezione != null)
            {
                //controllo che gli orari della presenza siano congrui con quelli della lezione
                var presenzaValida = ControllaLezioneAsync(presenza.IdLezione, presenza.DataOraInizio, presenza.DataOraFine);
                if (await presenzaValida)
                {
                    await _presenzaService.AddPresenzaAsync(presenza);
                   
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
                return BadRequest(ResponseFactory.WithError("Lezione non presente"));
            }
        }

        //endpoint per l'eliminazione di una presenza
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePresenzaAsync(DeletePresenzaRequest request)
        {
            if (await _presenzaService.GetPresenzaByIdAsync(request.IdPresenza) != null)
            {
                await _presenzaService.DeleteAsync(request.IdPresenza);
                return Ok(ResponseFactory.WithSuccess("Presenza Eliminata"));
            }
            return BadRequest(ResponseFactory.WithError("Presenza non presente"));
        }

        //metodo privato che conrtolla che gli orari della presenza siano congurui con quelli della lezione
        private async Task<bool> ControllaLezioneAsync(int idLezione, DateTime inizioPresenza, DateTime finePresenza)
        {
            var lezione = await _lezioneService.GetLezioneByIdAsync(idLezione);
            if(lezione != null)
            {
                if (inizioPresenza >= lezione.DataOraInizio && finePresenza <= lezione.DataOraFine)
                {
                    return true;
                }
            }
            return false;
        }

        //endpoint per la ricerca di una presenza
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchPresenze(SearchPresenzeRequest request)
        {
            var (search, totalNum) = await _presenzaService.Search(request.NomeCorso, request.CognomeStudente, request.CognomeDocente,
                request.DataLezione,request.Pagina,request.DimensionePagina);

           var response = new SearchPresenzeResponse();
           var pageFounded = (totalNum / (decimal)request.DimensionePagina);
           response.NumeroPagine = (int)Math.Ceiling(pageFounded);
           response.Presenze = search.Select(s =>
               new PresenzaDto(s)).ToList();

           return Ok(ResponseFactory
               .WithSuccess(response)
           );
        }
    }
}
