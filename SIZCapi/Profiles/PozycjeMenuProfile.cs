using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class PozycjeMenuProfile : Profile
    {
        public PozycjeMenuProfile()
        {
            CreateMap<PozycjaMenu, PobierzPozycjaMenuDto>();

            CreateMap<DodajPozycjaMenuDto, PozycjaMenu>();

            CreateMap<PozycjaMenu, DodajPozycjaMenuDto>();

            CreateMap<PozycjaMenu, DlaZamowieniePozycjaMenuDto>();
        }
    }
}