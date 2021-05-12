using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices
{
    public interface IIdiomaAppService
    {
        Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search);
        Task<IdiomaViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(IdiomaViewModel idiomaViewModel);
        Task EditAsync(IdiomaViewModel idiomaViewModel);
        Task RemoveAsync(IdiomaViewModel idiomaViewModel);
    }
}
