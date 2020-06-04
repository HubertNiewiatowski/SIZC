using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public AutoryzacjaKlientController(IAutoryzacjaKlient repozytorium, IMapper mapper)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        [HttpPost]
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

    }
}