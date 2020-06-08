using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class PlatnoscTypProfile : Profile
    {
        public PlatnoscTypProfile()
        {
            CreateMap<PlatnoscTyp, DlaZamowieniePlatnoscTypDto>();
        }    
    }
}