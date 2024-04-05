using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Options;


namespace Unicam.Paradigmi.Application.Services
{
    //Servizio per la crezione e gestione del JWT 
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;

        private readonly IUtenteService _utenteService;

        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, IUtenteService utenteService)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteService = utenteService;
        }

        //metodo per creare un token
        public async Task<string> CreateTokenAsync(string email, string password) { 

            var user = await _utenteService.GetUserByEmailAndPasswordAsync(email,password);

            if (user == null)
            {
                return "Richiesta non validata";
            }

            //aggiunta delle claims
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


            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;

        }


    }
}
