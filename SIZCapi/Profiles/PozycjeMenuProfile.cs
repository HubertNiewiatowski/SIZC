using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class PozycjeMenuProfile : Profile
    {
        public PozycjeMenuProfile()
        {
            CreateMap<PozycjaMenu, PobierzPozycjeMenuDto>();

            CreateMap<DodajPozycjeMenuDto, PozycjaMenu>();

            CreateMap<PozycjaMenu, DodajPozycjeMenuDto>();
        }
    }
}