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
    public class AutoryzacjaKlientController : ControllerBase
    {
        private readonly IAutoryzacjaKlient _repozytorium;
        private readonly IMapper _mapper;
        private readonly IConfiguration _konfiguracja;

        public AutoryzacjaKlientController(IAutoryzacjaKlient repozytorium, IMapper mapper, IConfiguration konfiguracja)
        {
            _konfiguracja = konfiguracja;
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        [HttpPost("zarejestruj")]
        public async Task<IActionResult> Zarejestruj(KlientDoRejestracjiDto klientRejestracja)
        {
            klientRejestracja.AdresEmail = klientRejestracja.AdresEmail.ToLower();

            if (await _repozytorium.CzyEmailIstnieje(klientRejestracja.AdresEmail))
            {
                return BadRequest("Konto o tym adresie email jest już zajęte");
            }

            var klientDoZarejestrowania = _mapper.Map<Klient>(klientRejestracja);

            await _repozytorium.Zarejestruj(klientDoZarejestrowania, klientRejestracja.Haslo);

            return NoContent();
        }

        [HttpPost("zaloguj")]
        public async Task<IActionResult> Zaloguj(KlientDoLogowaniaDto klientLogowanie)
        {
            var klientModel = await _repozytorium.Zaloguj(klientLogowanie.AdresEmail.ToLower(), klientLogowanie.Haslo);

            if (klientModel == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, klientModel.KlientID.ToString()),
                new Claim(ClaimTypes.Email, klientModel.AdresEmail),
                new Claim(ClaimTypes.Name, klientModel.Imie)
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