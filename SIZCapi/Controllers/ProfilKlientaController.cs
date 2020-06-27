using System;
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
    public class ProfilKlientaController : ControllerBase
    {
        private readonly ISIZCRepozytorium _repozytorium;
        private readonly IMapper _mapper;

        public ProfilKlientaController(ISIZCRepozytorium repozytorium, IMapper mapper)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        // GET http://localhost:5000/api/ProfilKlienta/{id}
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
        [HttpGet("{id}")]
        public async Task<IActionResult> PobierzProfilKlientaPoId(int id)
        {
            var profilKlienta = await _repozytorium.PobierzProfilKlienta(id);

            var profilKlientaDoPobrania = _mapper.Map<PobierzKlientDto>(profilKlienta);

            if (profilKlienta != null)
            {
                return Ok(profilKlientaDoPobrania);
            }
            return NotFound();
        }

        // PUT http://localhost:5000/api/ProfilKlienta/{id}
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AktualizujProfilKlienta(int id, PobierzKlientDto profilDoAktualizacji)
        {
            var profilModel = await _repozytorium.PobierzProfilKlienta(id);

            if (profilModel == null)
            {
                return NotFound();
            }

            _mapper.Map(profilDoAktualizacji, profilModel);

            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // DELETE http://localhost:5000/api/ProfilKlienta/{id}
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> UsunProfilKlienta(int id)
        {
            var profilModel = await _repozytorium.PobierzProfilKlienta(id);

            if (profilModel == null)
            {
                return NotFound();
            }

            _repozytorium.UsunZasob(profilModel);
            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // GET http://localhost:5000/api/ProfilKlienta/
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpGet("{dataPoczatkowa:datetime}/{dataKoncowa:datetime}")]
        public async Task<IActionResult> ZliczProfileKlientowDoRaportu(DateTime dataPoczatkowa, DateTime dataKoncowa)
        {
            var iloscKlientow = await _repozytorium.ZliczProfileKlientowDoRaportu(dataPoczatkowa, dataKoncowa);

            return Ok(iloscKlientow);

        }
        
    }
}