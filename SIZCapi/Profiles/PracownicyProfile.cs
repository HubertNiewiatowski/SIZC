using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class PracownicyProfile : Profile
    {
        public PracownicyProfile()
        {
            CreateMap<PracownikDoRejestracjiDto, Pracownik>();
        }    
    }
}