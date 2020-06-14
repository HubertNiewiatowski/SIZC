using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIZCapi.Data;
using SIZCapi.DTOs;

namespace SIZCapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilPracownikaController : ControllerBase
    {
        private readonly ISIZCRepozytorium _repozytorium;
        private readonly IMapper _mapper;
        
        public ProfilPracownikaController(ISIZCRepozytorium repozytorium, IMapper mapper)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        // GET http://localhost:5000/api/ProfilPracownika/{id}
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpGet("{id}")]
        public async Task<IActionResult> PobierzProfilPracownikaPoId(int id)
        {
            var profilPracownika = await _repozytorium.PobierzProfilPracownika(id);

            var profilPracownikaDoPobrania = _mapper.Map<PobierzPracownikDto>(profilPracownika);

            if (profilPracownika != null)
            {
                return Ok(profilPracownikaDoPobrania);
            }
            return NotFound();
        }

        // GET http://localhost:5000/api/ProfilPracownika/
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpGet]
        public async Task<IActionResult> PobierzProfilePracownikowWszystkie()
        {
            var profilePracownikow = await _repozytorium.PobierzProfilePracownikowWszystkie();

            var profilePracownikowDoPobrania = _mapper.Map<IEnumerable<PobierzPracownikDto>>(profilePracownikow);

            if (profilePracownikow != null)
            {
                return Ok(profilePracownikowDoPobrania);
            }
            return NotFound();
        }

        // PUT http://localhost:5000/api/ProfilPracownika/{id}
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AktualizujProfilPracownika(int id, PobierzPracownikDto profilDoAktualizacji)
        {
            var profilModel = await _repozytorium.PobierzProfilPracownika(id);

            if (profilModel == null)
            {
                return NotFound();
            }

            _mapper.Map(profilDoAktualizacji, profilModel);

            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // DELETE http://localhost:5000/api/ProfilPracownika/{id}
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> UsunProfilPracownika(int id)
        {
            var profilModel = await _repozytorium.PobierzProfilPracownika(id);

            if (profilModel == null)
            {
                return NotFound();
            }

            _repozytorium.UsunZasob(profilModel);
            await _repozytorium.ZapiszZasob();

            return NoContent();
        }
    }
}