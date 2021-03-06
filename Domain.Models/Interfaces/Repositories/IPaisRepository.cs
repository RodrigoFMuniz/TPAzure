using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPaisRepository
    {
        Task<IEnumerable<PaisEntity>> GetAllAsync(string search);
        Task<PaisEntity> GetByIdAsync(int id);
        Task<int> AddAsync(PaisEntity paisEntity);
        Task EditAsync(PaisEntity paisEntity);
        Task RemoveAsync(PaisEntity paisEntity);
    }
}
