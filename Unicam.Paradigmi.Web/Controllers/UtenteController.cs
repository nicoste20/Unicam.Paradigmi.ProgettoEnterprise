﻿using Microsoft.AspNetCore.Mvc;
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
        //creazione utente 

        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateUtenteRequest request) {
            var utente = request.ToEntity();
            var aggiuntaAvvenuta = _utenteService.AddUtente(utente);
            if (aggiuntaAvvenuta == false)
            {
                var response = new CreateUtenteResponse();
                response.utente = new UtenteDto(utente);
                return Ok(ResponseFactory.WithSuccess(response));
            }
            return Ok(ResponseFactory.WithError("Utente non aggiunto"));
        }
    }
}
