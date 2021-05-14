
using AutoMapper;
using Domain.Model.Models;
using WebApi.ViewModels;

namespace WebApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaisViewModel, PaisEntity>().ReverseMap();
            CreateMap<IdiomaViewModel, IdiomaEntity>().ReverseMap();
        }
 
    }
}
