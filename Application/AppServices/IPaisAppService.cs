using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices
{
    public interface IPaisAppService
    {
        Task<IEnumerable<PaisViewModel>> GetAllAsync(string search);
        Task<PaisViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(PaisViewModel paisViewModel);
        Task EditAsync(PaisViewModel paisViewModel);
        Task RemoveAsync(PaisViewModel paisViewModel);
    }
}
