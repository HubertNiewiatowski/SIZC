using AutoMapper;
using SIZCapi.DTOs;
using SIZCapi.Models;

namespace SIZCapi.Profiles
{
    public class ZamowieniaStatusProfile : Profile
    {
        public ZamowieniaStatusProfile()
        {
            CreateMap<ZamowienieStatus, DlaZamowienieZamowienieStatusDto>();
        }
        
    }
}