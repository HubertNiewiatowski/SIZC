using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SIZCapi.Data;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozycjeMenuController : ControllerBase
    {
        private readonly ISIZCRepozytorium _repozytorium;
        private readonly IMapper _mapper;

        public PozycjeMenuController(ISIZCRepozytorium repoztorium, IMapper mapper)
        {
            _repozytorium = repoztorium;
            _mapper = mapper;
        }

        // GET api/pozycjemenu
        [HttpGet]
        public async Task<ActionResult> PobierzPozycjeMenuWszystkie()
        {
            var pozycjeMenu = await _repozytorium.PobierzPozycjeMenuWszystkie();

            var pozycjeMenuDoPobrania = _mapper.Map<IEnumerable<PobierzPozycjeMenuDto>>(pozycjeMenu);

            if (pozycjeMenu != null)
            {
                return Ok(pozycjeMenuDoPobrania);
            }
            return NotFound();
        }

        // GET api/pozycjemenu/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> PobierzPozycjeMenuPoId(int id)
        {
            var pozycjaMenu = await _repozytorium.PobierzPozycjeMenuPoId(id);

            var pozycjaMenuDoPobrania = _mapper.Map<PobierzPozycjeMenuDto>(pozycjaMenu);

            if (pozycjaMenu != null)
            {
                return Ok(pozycjaMenuDoPobrania);
            }
            return NotFound();
        }

        // POST api/pozycjemenu
        [HttpPost]
        public async Task<ActionResult> DodajPozycjaMenu(DodajPozycjeMenuDto pozycjaDoDodania)
        {
            var pozycjaModel = _mapper.Map<PozycjaMenu>(pozycjaDoDodania);

            _repozytorium.DodajZasob(pozycjaModel);
            await _repozytorium.ZapiszZasob();

            return Ok();
        }

        // PUT api/pozycjemenu/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> AktualizujPozycjeMenu(int id, DodajPozycjeMenuDto pozycjaDoAktualizacji)
        {
            var pozycjaModel = await _repozytorium.PobierzPozycjeMenuPoId(id);

            if (pozycjaModel == null)
            {
                return NotFound();
            }

            _mapper.Map(pozycjaDoAktualizacji, pozycjaModel);

            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // PATCH api/pozycjemenu/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> AktualizujCzesciowoPozycjeMenu(int id, JsonPatchDocument<DodajPozycjeMenuDto> dokumentAktualizacji)
        {
            var pozycjaModel = await _repozytorium.PobierzPozycjeMenuPoId(id);

            if (pozycjaModel == null)
            {
                return NotFound();
            }

            var pozycjaDoAktualizacji = _mapper.Map<DodajPozycjeMenuDto>(pozycjaModel);

            dokumentAktualizacji.ApplyTo(pozycjaDoAktualizacji, ModelState);

            if (!TryValidateModel(pozycjaDoAktualizacji))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(pozycjaDoAktualizacji, pozycjaModel);

            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // DELETE api/pozycjemenu/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> UsunPozycjeMenu(int id)
        {
            var pozycjaModel = await _repozytorium.PobierzPozycjeMenuPoId(id);

            if (pozycjaModel == null)
            {
                return NotFound();
            }

            _repozytorium.UsunZasob(pozycjaModel);
            await _repozytorium.ZapiszZasob();

            return NoContent();
        }
    }
}