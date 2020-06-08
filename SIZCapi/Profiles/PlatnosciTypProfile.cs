using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class PlatnosciTypProfile : Profile
    {
        public PlatnosciTypProfile()
        {
            CreateMap<PlatnoscTyp, DlaZamowieniePlatnoscTypDto>();
        }    
    }
}