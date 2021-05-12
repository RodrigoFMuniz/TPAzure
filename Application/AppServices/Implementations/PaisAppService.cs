using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices.Implementations
{
    public class PaisAppService : IPaisAppService
    {
        private readonly IPaisAppService _paisAppService;

        public PaisAppService(IPaisAppService paisAppService)
        {
            _paisAppService = paisAppService;
        }

        public async Task<int> AddAsync(PaisViewModel paisViewModel)
        {
            return await _paisAppService.AddAsync(paisViewModel);
        }

        public async Task EditAsync(PaisViewModel paisViewModel)
        {
            await _paisAppService.EditAsync(paisViewModel);
        }

        public async Task<IEnumerable<PaisViewModel>> GetAllAsync(string search)
        {
            return await _paisAppService.GetAllAsync(search);
        }

        public async Task<PaisViewModel> GetByIdAsync(int id)
        {
            return await _paisAppService.GetByIdAsync(id);
        }

        public async Task RemoveAsync(PaisViewModel paisViewModel)
        {
            await _paisAppService.RemoveAsync(paisViewModel);
        }
    }
}
