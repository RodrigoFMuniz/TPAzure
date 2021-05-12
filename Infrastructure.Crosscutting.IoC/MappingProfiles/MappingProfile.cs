using Application.ViewModels;
using AutoMapper;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Crosscutting.IoC.MappingProfiles
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
