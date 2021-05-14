using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPAzure.ViewModels;

namespace TPAzure.HttpServices
{
    public interface IIdiomaHttpService
    {           
        Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search);
        Task<IdiomaViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(IdiomaViewModel idiomaViewModel);
        Task EditAsync(IdiomaViewModel idiomaViewModel);
        Task RemoveAsync(IdiomaViewModel idiomaViewModel);
    }
}
