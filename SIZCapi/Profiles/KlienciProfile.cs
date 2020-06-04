using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class KlienciProfile : Profile
    {
        public KlienciProfile()
        {
            CreateMap<KlientDoRejestracjiDto, Klient>();
        }
        
    }
}