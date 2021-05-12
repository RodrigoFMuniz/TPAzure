using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices.Implementations
{
    public class IdiomaAppService : IIdiomaAppService
    {
        private readonly IIdiomaAppService _idiomaAppService;

        public IdiomaAppService(IIdiomaAppService idiomaAppService)
        {
            _idiomaAppService = idiomaAppService;
        }

        public async Task<int> AddAsync(IdiomaViewModel idiomaViewModel)
        {
            return await _idiomaAppService.AddAsync(idiomaViewModel);
        }

        public async Task EditAsync(IdiomaViewModel idiomaViewModel)
        {
            await _idiomaAppService.EditAsync(idiomaViewModel);
        }

        public async Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search)
        {
            return await _idiomaAppService.GetAllAsync(search);
        }

        public async Task<IdiomaViewModel> GetByIdAsync(int id)
        {
            return await _idiomaAppService.GetByIdAsync(id);
        }

        public async Task RemoveAsync(IdiomaViewModel idiomaViewModel)
        {
            await _idiomaAppService.RemoveAsync(idiomaViewModel);
        }
    }
}
