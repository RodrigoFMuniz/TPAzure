using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IIdiomaRepository
    {
        Task<IEnumerable<IdiomaEntity>> GetAllAsync(string search);
        Task<IdiomaEntity> GetByIdAsync(int id);
        Task<int> AddAsync(IdiomaEntity idiomaEntity);
        Task EditAsync(IdiomaEntity idiomaEntity);
        Task RemoveAsync(IdiomaEntity idiomaEntity);
    }
}
