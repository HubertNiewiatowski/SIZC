using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class ZamowieniaProfile : Profile
    {
        public ZamowieniaProfile()
        {
            CreateMap<Zamowienie, PobierzZamowienieDto>();

            CreateMap<DodajZamowienieDto, Zamowienie>();
        }
    }
}