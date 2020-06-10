using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIZCapi.Data;
using SIZCapi.DTOs;

namespace SIZCapi.Controllers
{
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
        [HttpGet("{id}")]
        public async Task<IActionResult> PobierzProfilKlienta(int id)
        {
            var profilKlienta = await _repozytorium.PobierzProfilKlienta(id);

            var profilKlientaDoPobrania = _mapper.Map<PobierzKlientDto>(profilKlienta);

            if (profilKlienta != null)
            {
                return Ok(profilKlientaDoPobrania);
            }
            return NotFound();
        }
        
    }
}