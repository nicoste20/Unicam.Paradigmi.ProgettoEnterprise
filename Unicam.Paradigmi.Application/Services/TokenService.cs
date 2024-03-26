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
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;

        private readonly UtenteRepository _utenteRepository;

        public TokenService(JwtAuthenticationOption jwtAuthOption, UtenteRepository utenteRepository)
        {
            _jwtAuthOption = jwtAuthOption;
            _utenteRepository = utenteRepository;
        }

        public string CreateToken(CreateTokenRequest request) { 

            //TODO: controllare esattezza coppia
            var response = ValidaRichiesta(request.Email,request.Password);

            if (!response)
            {
                return "Richiesta non validata";
            }

            // Ottieni l'utente dal servizio utente utilizzando l'email fornita nella richiesta
            var user = _utenteRepository.GetUserByEmail(request.Email);


            // Creazione delle claims
            var claims = new List<Claim>
            {
                // Aggiungi l'email come claim
                new Claim(ClaimTypes.Email, user.Email),
                // Aggiungi la password come claim 
                new Claim("Password", request.Password),
            };


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

        private bool ValidaRichiesta(string email, string password)
        {
            // Cerca l'utente nel database utilizzando l'email fornita nella richiesta
            var user = _utenteRepository.GetUserByEmail(email);

            // Se non viene trovato nessun utente con quella email, la richiesta non è valida
            if (user == null)
            {
                return false;
            }

            // Verifica se la password fornita nella richiesta corrisponde alla password dell'utente nel database
            bool isPasswordValid = _utenteRepository.VerifyPassword(user, password);

            // Restituisci true se l'email e la password sono valide, altrimenti false
            return isPasswordValid;
        }
    }
}
