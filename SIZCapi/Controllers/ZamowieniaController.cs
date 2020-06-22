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
using MailKit;
using MimeKit;


namespace SIZCapi.Controllers
{
    [Authorize]
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

        // GET http://localhost:5000/api/Zamowienia/
        [Authorize(Policy = "WymaganeUprawnieniaAdministratora")]
        [HttpGet("{dataPoczatkowa:datetime}/{dataKoncowa:datetime}")]
        public async Task<IActionResult> ZliczZamowieniaDoRaportu(DateTime dataPoczatkowa, DateTime dataKoncowa)
        {
            var iloscZamowien = await _repozytorium.ZliczZamowieniaDoRaportu(dataPoczatkowa, dataKoncowa);

            return Ok(iloscZamowien);
        }

        // GET http://localhost:5000/api/Zamowienia/{id}
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

        // GET http://localhost:5000/api/Zamowienia/{id}
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

        // GET http://localhost:5000/api/Zamowienia/klient/{id}
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
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

        // POST http://localhost:5000/api/Zamowienia/klient
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]
        [HttpPost("klient")]
        public async Task<IActionResult> DodajZamowienieKlienta(DodajZamowienieDto zamowienieDoDodania)
        {
            zamowienieDoDodania.DataZlozenia =  DateTime.Now;

            zamowienieDoDodania.PracownikID = 1;

            zamowienieDoDodania.ZamowienieStatusID = 1;

            var zamowienieModel = _mapper.Map<Zamowienie>(zamowienieDoDodania);

            _repozytorium.DodajZasob(zamowienieModel);
            await _repozytorium.ZapiszZasob();

            return Ok();
        }

        // PUT http://localhost:5000/api/Zamowienia/{id}
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AktualizujZamowienie(int id, AktualizujZamowienieDto zamowienieDoAktualizacji)
        {
            var zamowienieModel = await _repozytorium.PobierzZamowieniePoId(id);

            if (zamowienieModel == null)
            {
                return NotFound();
            }

            _mapper.Map(zamowienieDoAktualizacji, zamowienieModel);

            await _repozytorium.ZapiszZasob();

            return NoContent();
        }

        // POST http://localhost:5000/api/Zamowienia/mail/{id}
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]
        [HttpPost("mail/{idKlient}/{idZamowienie}")]
        public async Task<IActionResult> WyslijEmail(int idKlient, int idZamowienie)
        {
            string adresEmailKlienta = await _repozytorium.PobierzAdresEmailKlienta(idKlient);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Dostawca", "api.sizc.8001@gmail.com"));

            message.To.Add(new MailboxAddress("Klient", adresEmailKlienta));

            message.Subject = "Zamówienie o id " + idZamowienie.ToString() + " jest w trakcie dostawy";

            message.Body = new TextPart("plain")
            {
                Text = "Drogi Kliencie Firmy Cateringowej, chcielibyśmy Cię poinformować o tym, że zamówienie o id " + idZamowienie.ToString() + " jest w trakcie dostawy"
            };

            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("api.sizc.8001@gmail.com", "P@$sw0rd!");

                client.Send(message);

                client.Disconnect(true);
            }

            return Ok();
        }
        
    }
}