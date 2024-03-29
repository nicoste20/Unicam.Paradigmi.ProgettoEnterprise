﻿using Azure;
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
        public async Task<IActionResult> CreatePresenzaAsync(CreatePresenzaRequest request )
        {
            var presenza = request.ToEntity();
            var alunno = await _utenteService.GetUserByEmailAsync(request.EmailAlunno);
            presenza.IdAlunno = alunno.IdUtente;

            if (await _utenteService.GetUserByIdAsync(presenza.IdAlunno) !=null && await _lezioneService.GetLezioneByIdAsync(presenza.IdLezione) != null)
            {
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
                return BadRequest(ResponseFactory.WithError("Presenza nulla"));
            }
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePresenzaAsync(DeletePresenzaRequest request)
        {
            await _presenzaService.DeleteAsync(request.IdPresenza);
            return Ok(ResponseFactory.WithSuccess("Presenza Eliminata"));
        }

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

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchPresenze(SearchPresenzeRequest request)
        {
            var (search, totalNum) = await _presenzaService.Search(request.courseName, request.studentSurname, request.lecturerSurname,
                request.lessonDate,request.page,request.pageSize);

           var response = new SearchPresenzeResponse();
           var pageFounded = (totalNum / (decimal)request.pageSize);
           response.NumeroPagine = (int)Math.Ceiling(pageFounded);
           response.Presenze = search.Select(s =>
               new PresenzaDto(s)).ToList();

           return Ok(ResponseFactory
               .WithSuccess(response)
           );
        }
    }
}
