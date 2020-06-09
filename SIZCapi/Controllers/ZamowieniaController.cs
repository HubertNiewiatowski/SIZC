using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIZCapi.Data;
using SIZCapi.DTOs;

namespace SIZCapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamowieniaController : ControllerBase
    {
        private readonly ISIZCRepozytorium _repozytorium;
        private readonly IMapper _mapper;

        public ZamowieniaController(ISIZCRepozytorium repozytorium, IMapper mapper)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
        }

        // GET http://localhost:5000/api/Zamowienia/klient/{id}
        [HttpGet("klient/{id}")]
        public async Task<IActionResult> PobierzZamowieniaKlienta(int id)
        {
            var zamowienia = await _repozytorium.PobierzZamowieniaKlienta(id);

            var zamowieniaDoPobrania = _mapper.Map<IEnumerable<PobierzZamowienieDto>>(zamowienia);

            if (zamowienia != null)
            {
                return Ok(zamowieniaDoPobrania);
            }
            return NotFound();
        }
        
    }
}