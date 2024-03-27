﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LezioneController : ControllerBase
    {
        private readonly ILezioneService _lezioneService;

        public LezioneController(ILezioneService lezioneService)
        {
            _lezioneService = lezioneService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateLezione(CreateLezioneRequest request)
        {
            var lezione = request.ToEntity();
            if(lezione == null)
            {
                return BadRequest(ResponseFactory.WithError("Lezione nulla"));
            }
            _lezioneService.AddLezione(lezione);

            var response = new CreateLezioneResponse();
            response.Lezione = new LezioneDto(lezione);
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}