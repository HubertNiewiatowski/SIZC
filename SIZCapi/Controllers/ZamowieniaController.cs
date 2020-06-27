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
        private readonly ISIZCRepozytorium _repozytorium;
        private readonly IMapper _mapper;
        private readonly IConfiguration _konfiguracja;

        // Wstrzykiwanie zależności do konstruktora
        public ZamowieniaController(ISIZCRepozytorium repozytorium, IMapper mapper, IConfiguration konfiguracja)
        {
            // Repozytorium SIZC umożliwia wykonywanie operacji na bazie danych
            _repozytorium = repozytorium;

            // Automapper umożliwia mapowanie obiektów z modelu danych na postać wykorzystywaną w akcjach kontrolera
            _mapper = mapper;

            // Konfiguracja aplikacji zapewnia dostęp do appsettings.json
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


        // Metoda wymagająca autoryzacji opartej o poświadczenie uprawnień 
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]

        // Metoda HTTP Get umożliwiająca pobieranie obiektów z WebAPI
        [HttpGet("klient/{id}")]

        // Metoda przekazuje id klienta w argumencie
        public async Task<IActionResult> PobierzZamowieniaKlienta(int id)
        {
            // Pobranie z bazy danych zamówień przypisanych do klienta o id przekazanym w argumencie
            var zamowienia = await _repozytorium.PobierzZamowieniaKlienta(id);

            // Mapowanie z klasy modelu na PobierzZamowienieDto
            var zamowieniaDoPobrania = _mapper.Map<IEnumerable<PobierzZamowienieDto>>(zamowienia);

            // Jeśli zamówienia o wskazanym do klienta o wskazanym id istnieją, zostaną zwrócone przez WebAPI
            if (zamowienia != null)
            {
                return Ok(zamowieniaDoPobrania);
            }

            // W przeciwnym razie zwrócony zostanie status NotFound 
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

        // Metoda wymagająca autoryzacji opartej o poświadczenie uprawnień 
        [Authorize(Policy = "WymaganeUprawnieniaKlienta")]

        // Metoda HTTP Post umożliwiająca wysyłanie obiektów do WebAPI
        [HttpPost("klient")]

        // Metoda przekazuje obiekt zamówienia w argumencie
        public async Task<IActionResult> DodajZamowienieKlienta(DodajZamowienieDto zamowienieDoDodania)
        {
            // Data złożenia zamówienia ustawiana jest na aktualną datę
            zamowienieDoDodania.DataZlozenia = DateTime.Now;

            // Mapowanie z DodajZamowienieDto na klasę modelu - Zamowienie
            var zamowienieModel = _mapper.Map<Zamowienie>(zamowienieDoDodania);

            // Dodanie w bazie danych rekordu zawierającego zmapowane zamówienie
             _repozytorium.DodajZasob(zamowienieModel);

            // Zapisanie zmian w bazie danych z wykorzystaniem metody asynchronicznej
            await _repozytorium.ZapiszZasob();

            // Jeśli zamówienie zostało zapisane w bazie danych, zwrócony zostanie status OK
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

        // Metoda wymagająca autoryzacji opartej o poświadczenie uprawnień
        [Authorize(Policy = "WymaganeUprawnieniaPracownika")]

        // Metoda HTTP Post umożliwiająca wysyłanie obiektów do WebAPI
        [HttpPost("email/{idKlient}/{idZamowienie}")]

        // Metoda przekazuje w argumencie id klienta oraz id zamówienia
        public async Task<IActionResult> WyslijEmail(int idKlient, int idZamowienie)
        {
            // Pobranie adresu email skrzynki mailowej nadawcy z konfiguracji aplikacji
            string adresEmail = _konfiguracja.GetSection("MailKitSettings:Email").Value;

            // Pobranie hasła do skrzynki mailowej nadawcy z konfiguracji aplikacji
            string haslo = _konfiguracja.GetSection("MailKitSettings:Password").Value;

            // Pobranie z bazy danych adresu email klienta o wskazanym id
            string adresEmailKlienta = await _repozytorium.PobierzAdresEmailKlienta(idKlient);

            // W przypadku gdy adres email klienta o wskazanym id nie istnieje
            // Zostanie zwrócony status NotFound
            if (adresEmailKlienta == null)
            {
                return NotFound();
            }

            // Utworzenie obiektu wiadomości
            var message = new MimeMessage();

            // Ustawienie 
            message.From.Add(new MailboxAddress("Dostawca Firmy Cateringowej", adresEmail));

            message.To.Add(new MailboxAddress("Klient", adresEmailKlienta));

            message.Subject = "Zamówienie o id " + idZamowienie.ToString() + " jest w trakcie dostawy";

            message.Body = new TextPart("plain")
            {
                Text = "Drogi Kliencie Firmy Cateringowej,"
                    + " chcielibyśmy Cię poinformować o tym, że zamówienie o id "
                    + idZamowienie.ToString() + " jest w trakcie dostawy."
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.AuthenticateAsync(adresEmail, haslo);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }

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