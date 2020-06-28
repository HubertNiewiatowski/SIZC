using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIZCapi.Data;
using SIZCapi.DTOs;
using SIZCapi.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace SIZCapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]


    public class ZamowieniaController : ControllerBase
    {
        // 1
        private readonly ISIZCRepozytorium _repozytorium;
        
        // 2
        private readonly IMapper _mapper;
        
        // 3
        private readonly IConfiguration _konfiguracja;

        // 4
        public ZamowieniaController(ISIZCRepozytorium repozytorium, IMapper mapper, IConfiguration konfiguracja)
        {
            _repozytorium = repozytorium;
            _mapper = mapper;
            _konfiguracja = konfiguracja;
        }


        // GET /api/Zamowienia/{id}
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpGet("{id}")]
        public async Task<IActionResult> PobierzZamowieniePoId(int id)
        {
            var zamowienie = await _repozytorium.PobierzZamowieniePoId(id);

            var zamowienieDoPobrania = _mapper.Map<PobierzZamowienieDto>(zamowienie);

            if (zamowienie != null)
            {
                return Ok(zamowienieDoPobrania);
            }
            return NotFound();
        }

        // Metoda wymagająca autoryzacji opartej o poświadczenie uprawnień pracownika
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpGet("aktualizacja/{id}")]
        public async Task<IActionResult> PobierzZamowienieDoAktualizacji(int id)
        {
            var zamowienie = await _repozytorium.PobierzZamowieniePoId(id);

            var zamowienieDoPobrania = _mapper.Map<AktualizujZamowienieDto>(zamowienie);

            if (zamowienie != null)
            {
                return Ok(zamowienieDoPobrania);
            }
            return NotFound();
        }


        // 1
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]

        // 2
        [HttpGet("klient/{id}")]

        // 3
        public async Task<IActionResult> PobierzZamowieniaKlienta(int id)
        {
            // 4
            var zamowienia = await _repozytorium.PobierzZamowieniaKlienta(id);

            // 5
            var zamowieniaDoPobrania = _mapper.Map<IEnumerable<PobierzZamowienieDto>>(zamowienia);

            // 6
            if (zamowienia != null)
            {
                return Ok(zamowieniaDoPobrania);
            }

            // 7
            return NotFound();
        }

        // GET http://localhost:5000/api/Zamowienia/pracownik/{id}
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpGet("pracownik/{id}")]
        public async Task<IActionResult> PobierzZamowieniaPracownika(int id)
        {
            var zamowienia = await _repozytorium.PobierzZamowieniaPracownika(id);

            var zamowieniaDoPobrania = _mapper.Map<IEnumerable<PobierzZamowienieDto>>(zamowienia);

            if (zamowienia != null)
            {
                return Ok(zamowieniaDoPobrania);
            }
            return NotFound();
        }

        // 1
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]

        // 2
        [HttpPost("klient")]

        // 3
        public async Task<IActionResult> DodajZamowienieKlienta(DodajZamowienieDto zamowienieDoDodania)
        {
            // 4
            zamowienieDoDodania.DataZlozenia = DateTime.Now;

            // 5
            var zamowienieModel = _mapper.Map<Zamowienie>(zamowienieDoDodania);

            // 6
             _repozytorium.DodajZasob(zamowienieModel);

            // 7
            await _repozytorium.ZapiszZasob();

            // 8
            return Ok();
        }

        // 1
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]

        // 2
        [HttpPut("{id}")]

        // 3
        public async Task<IActionResult> AktualizujZamowienie(int id, AktualizujZamowienieDto zamowienieDoAktualizacji)
        {
            // 4
            var zamowienieModel = await _repozytorium.PobierzZamowieniePoId(id);

            // 5
            if (zamowienieModel == null)
            {
                return NotFound();
            }

            // 6
            _mapper.Map(zamowienieDoAktualizacji, zamowienieModel);

            // 7
            await _repozytorium.ZapiszZasob();

            // 8
            return Ok();
        }

        // 1
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]

        // 2
        [HttpPost("email/{idKlient}/{idZamowienie}")]

        // 3
        public async Task<IActionResult> WyslijEmail(int idKlient, int idZamowienie)
        {
            // 4
            string adresEmail = _konfiguracja.GetSection("MailKitSettings:Email").Value;

            // 5
            string haslo = _konfiguracja.GetSection("MailKitSettings:Password").Value;

            // 6
            string adresEmailKlienta = await _repozytorium.PobierzAdresEmailKlienta(idKlient);

            // 7
            if (adresEmailKlienta == null)
            {
                return NotFound();
            }

            // 8
            var message = new MimeMessage();

            // 9
            message.From.Add(new MailboxAddress("Dostawca Firmy Cateringowej", adresEmail));

            // 10
            message.To.Add(new MailboxAddress("Klient", adresEmailKlienta));

            // 11
            message.Subject = "Zamówienie o id " + idZamowienie.ToString() + " jest w trakcie dostawy";

            // 12
            message.Body = new TextPart("plain")
            {
                Text = "Drogi Kliencie Firmy Cateringowej,"
                    + " chcielibyśmy Cię poinformować o tym, że zamówienie o id "
                    + idZamowienie.ToString() + " jest w trakcie dostawy."
            };

            // 13
            using (var klient = new SmtpClient())
            {
                // 14
                await klient.ConnectAsync("smtp.gmail.com", 587);

                // 15
                klient.AuthenticationMechanisms.Remove("XOAUTH2");

                // 16
                await klient.AuthenticateAsync(adresEmail, haslo);

                // 17
                await klient.SendAsync(message);

                // 18
                await klient.DisconnectAsync(true);
            }

            // 19
            return Ok();
        }

        // GET http://localhost:5000/api/Zamowienia/platnoscTyp/
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
        [HttpGet("platnoscTyp")]
        public async Task<IActionResult> PobierzTypyPlatnosci()
        {
            var typyPlatnosci = await _repozytorium.PobierzTypyPlatnosci();

            var typyPlatnosciDoPobrania = _mapper.Map<IEnumerable<DlaZamowieniePlatnoscTypDto>>(typyPlatnosci);

            if (typyPlatnosci != null)
            {
                return Ok(typyPlatnosciDoPobrania);
            }
            return NotFound();
        }

        // GET http://localhost:5000/api/Zamowienia/zamowienieStatus/
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpGet("zamowienieStatus")]
        public async Task<IActionResult> PobierzStatusyZamowien()
        {
            var statusyZamowien = await _repozytorium.PobierzStatusyZamowien();

            var statusyZamowienDoPobrania = _mapper.Map<IEnumerable<DlaZamowienieZamowienieStatusDto>>(statusyZamowien);

            if (statusyZamowien != null)
            {
                return Ok(statusyZamowienDoPobrania);
            }
            return NotFound();
        }

        // GET http://localhost:5000/api/Zamowienia/
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpGet("{dataPoczatkowa:datetime}/{dataKoncowa:datetime}")]
        public async Task<IActionResult> ZliczZamowieniaDoRaportu(DateTime dataPoczatkowa, DateTime dataKoncowa)
        {
            var iloscZamowien = await _repozytorium.ZliczZamowieniaDoRaportu(dataPoczatkowa, dataKoncowa);

            return Ok(iloscZamowien);
        }
    }
}