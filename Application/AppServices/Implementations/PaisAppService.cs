using Application.ViewModels;
using Domain.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Model.Models;

namespace Application.AppServices.Implementations
{
    public class PaisAppService : IPaisAppService
    {
        private readonly IPaisService _paisService;
        private readonly IMapper _mapper;

        public PaisAppService(IPaisService paisService, IMapper mapper)
        {
            _mapper = mapper;
            _paisService = paisService;
        }

        public async Task<int> AddAsync(PaisViewModel paisViewModel)
        {
            var pais = _mapper.Map<PaisEntity>(paisViewModel);
            var id = await _paisService.AddAsync(pais);
            return id;
        }

        public async Task EditAsync(PaisViewModel paisViewModel)
        {
            var pais = _mapper.Map<PaisEntity>(paisViewModel);
            await _paisService.EditAsync(pais);
        }

        public async Task<IEnumerable<PaisViewModel>> GetAllAsync(string search)
        {
            var paises = await _paisService.GetAllAsync(search);
            return _mapper.Map<IEnumerable<PaisViewModel>>(paises);
        }

        public async Task<PaisViewModel> GetByIdAsync(int id)
        {
            var pais =  await _paisService.GetByIdAsync(id);
            return _mapper.Map<PaisViewModel>(pais);
        }

        public async Task RemoveAsync(PaisViewModel paisViewModel)
        {
            var pais = _mapper.Map<PaisEntity>(paisViewModel);
            await _paisService.RemoveAsync(pais);
        }
    }
}
