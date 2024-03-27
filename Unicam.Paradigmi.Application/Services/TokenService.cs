using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;

        private readonly IUtenteService _utenteService;

        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, IUtenteService utenteService)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteService = utenteService;
        }

        public string CreateToken(string email, string password) { 

            var user = _utenteService.GetUserByEmailAndPassword(email,password);

            if (user == null)
            {
                return "Richiesta non validata";
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", $"{user.IdUtente}"));

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );
            //credenziali di firma
            var credentials = new SigningCredentials(securityKey
            , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );


            var token = new JwtSecurityTokenHandler().WriteToken( securityToken );
            return token;

        }
    }
}
