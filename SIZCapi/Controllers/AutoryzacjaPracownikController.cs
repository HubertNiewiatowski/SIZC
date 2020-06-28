using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIZCapi.Data;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AutoryzacjaPracownikController : ControllerBase
    {
        // 1 
        private readonly IAutoryzacjaPracownik _repozytorium;
        
        // 2
        private readonly IMapper _mapper;
        
        // 3
        private readonly IConfiguration _konfiguracja;

        // 4
        public AutoryzacjaPracownikController(IAutoryzacjaPracownik repozytorium, IMapper mapper, IConfiguration konfiguracja)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
            _konfiguracja = konfiguracja;
        }




        // 1
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]

        // 2
        [HttpPost("zarejestruj")]

        // 3
        public async Task<IActionResult> Zarejestruj(PracownikDoRejestracjiDto pracownikRejestracja)
        {
            // 4
            pracownikRejestracja.Login = pracownikRejestracja.Login.ToLower();

            // 5
            if (await _repozytorium.CzyLoginIstnieje(pracownikRejestracja.Login))
            {
                return BadRequest("Konto o tym loginie już istnieje");
            }

            // 6
            var pracownikDoZarejestrowania = _mapper.Map<Pracownik>(pracownikRejestracja);

            // 7
            await _repozytorium.Zarejestruj(pracownikDoZarejestrowania, pracownikRejestracja.Haslo);

            // 8
            return Ok();
        }



        // 1
        [HttpPost("zaloguj")]

        // 2
        public async Task<IActionResult> Zaloguj(PracownikDoLogowaniaDto pracownikLogowanie)
        {
            // 3
            var pracownikModel = await _repozytorium.Zaloguj(pracownikLogowanie.Login.ToLower(), pracownikLogowanie.Haslo);

            // 4
            if (pracownikModel == null)
            {
                return Unauthorized();
            }

            // 5
            var claims = new Claim [4];

            // 6
            switch(pracownikModel.PracownikRolaID) 
            {                
                // 7
                case 1:
                    claims [0] = new Claim(ClaimTypes.NameIdentifier, pracownikModel.PracownikID.ToString());
                    claims [1] = new Claim("UprawnieniaPracownik", "");
                    claims [2] = new Claim(ClaimTypes.Name, pracownikModel.Login);
                    claims [3] = new Claim("PracownikRolaId", pracownikModel.PracownikRolaID.ToString());
                    break;
                case 2:
                    claims [0] = new Claim(ClaimTypes.NameIdentifier, pracownikModel.PracownikID.ToString());
                    claims [1] = new Claim("UprawnieniaPracownik", "");
                    claims [2] = new Claim(ClaimTypes.Name, pracownikModel.Login);
                    claims [3] = new Claim("PracownikRolaId", pracownikModel.PracownikRolaID.ToString());
                    break;
                case 3:
                    claims [0] = new Claim(ClaimTypes.NameIdentifier, pracownikModel.PracownikID.ToString());
                    claims [1] = new Claim("UprawnieniaAdministrator", "");
                    claims [2] = new Claim(ClaimTypes.Name, pracownikModel.Login);
                    claims [3] = new Claim("PracownikRolaId", pracownikModel.PracownikRolaID.ToString());
                    break;
            }

            // 8
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_konfiguracja.GetSection("AppSettings:Token").Value));

            // 9
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // 10
            var descriptor = new SecurityTokenDescriptor
            {
                // 11
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = credentials
            };

            // 12
            var handler = new JwtSecurityTokenHandler();

            // 13
            var token = handler.CreateToken(descriptor);

            // 14
            return Ok
            (
                new {token = handler.WriteToken(token)}
            );            
        }        
    }
}