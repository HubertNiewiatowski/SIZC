using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IAutoryzacjaPracownik _repozytorium;
        private readonly IMapper _mapper;
        private readonly IConfiguration _konfiguracja;

        public AutoryzacjaPracownikController(IAutoryzacjaPracownik repozytorium, IMapper mapper, IConfiguration konfiguracja)
        {
            _konfiguracja = konfiguracja;
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        // POST api/AutoryzacjaPracownik/zarejestruj
        [HttpPost("zarejestruj")]
        public async Task<IActionResult> Zarejestruj(PracownikDoRejestracjiDto pracownikRejestracja)
        {
            pracownikRejestracja.Login = pracownikRejestracja.Login.ToLower();

            if (await _repozytorium.CzyLoginIstnieje(pracownikRejestracja.Login))
            {
                return BadRequest("Konto o tym adresie email jest już zajęte");
            }

            var pracownikDoZarejestrowania = _mapper.Map<Pracownik>(pracownikRejestracja);

            await _repozytorium.Zarejestruj(pracownikDoZarejestrowania, pracownikRejestracja.Haslo);

            return NoContent();
        }

        // POST /api/AutoryzacjaPracownik/zaloguj
        [HttpPost("zaloguj")]
        public async Task<IActionResult> Zaloguj(PracownikDoLogowaniaDto pracownikLogowanie)
        {
            var pracownikModel = await _repozytorium.Zaloguj(pracownikLogowanie.Login.ToLower(), pracownikLogowanie.Haslo);

            if (pracownikModel == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, pracownikModel.PracownikID.ToString()),
                new Claim(ClaimTypes.Name, pracownikModel.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_konfiguracja.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = credentials
            };

            var handler = new JwtSecurityTokenHandler();

            var token = handler.CreateToken(descriptor);

            return Ok
            (
                new {token = handler.WriteToken(token)}
            );    
            
        }        
    }
}