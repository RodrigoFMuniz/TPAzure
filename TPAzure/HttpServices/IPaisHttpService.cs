using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPAzure.ViewModels;

namespace TPAzure.HttpServices
{
    public interface IPaisHttpService
    {
        Task<IEnumerable<PaisViewModel>> GetAllAsync(string search);
        Task<PaisViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(PaisViewModel paisViewModel);
        Task EditAsync(PaisViewModel paisViewModel);
        Task RemoveAsync(PaisViewModel paisViewModel);
    }

}
