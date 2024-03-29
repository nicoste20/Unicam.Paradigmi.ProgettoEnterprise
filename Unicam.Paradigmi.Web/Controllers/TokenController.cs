using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Data;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {

        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest request)
        {
            string token = await _tokenService.CreateTokenAsync(request.Email,request.Password);

            if (token != null)
            {
                return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
            }
            return BadRequest(ResponseFactory.WithError("Email o Password errata"));
        }
        
    }
}
