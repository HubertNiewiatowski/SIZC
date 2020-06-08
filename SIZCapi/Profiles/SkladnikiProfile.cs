using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class SkladnikiProfile : Profile
    {
        public SkladnikiProfile()
        {
            CreateMap<Skladnik, DlaPozycjaMenuSkladnikDto>();
        }
        
    }
}