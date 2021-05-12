using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Models;
using Domain.Model.Interfaces.Services;
using AutoMapper;

namespace Application.AppServices.Implementations
{
    public class IdiomaAppService : IIdiomaAppService
    {
        private readonly IIdiomaService _idiomaService;
        private readonly IMapper _mapper;

        public IdiomaAppService(IIdiomaService idiomaService, IMapper mapper)
        {
            _mapper = mapper;
            _idiomaService = idiomaService;
        }

        public async Task<int> AddAsync(IdiomaViewModel idiomaViewModel)
        {
            var idioma = _mapper.Map<IdiomaEntity>(idiomaViewModel);
            var id = await _idiomaService.AddAsync(idioma);
            return id;
        }

        public async Task EditAsync(IdiomaViewModel idiomaViewModel)
        {
            var idioma = _mapper.Map<IdiomaEntity>(idiomaViewModel);
            await _idiomaService.EditAsync(idioma);
        }

        public async Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search)
        {
            var idiomaes = await _idiomaService.GetAllAsync(search);
            return _mapper.Map<IEnumerable<IdiomaViewModel>>(idiomaes);
        }

        public async Task<IdiomaViewModel> GetByIdAsync(int id)
        {
            var idioma = await _idiomaService.GetByIdAsync(id);
            return _mapper.Map<IdiomaViewModel>(idioma);
        }

        public async Task RemoveAsync(IdiomaViewModel idiomaViewModel)
        {
            var idioma = _mapper.Map<IdiomaEntity>(idiomaViewModel);
            await _idiomaService.RemoveAsync(idioma);
        }
    }
}
