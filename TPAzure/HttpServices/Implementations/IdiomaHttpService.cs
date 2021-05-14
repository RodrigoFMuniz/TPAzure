using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPAzure.ViewModels;

namespace TPAzure.HttpServices.Implementations
{
    public class IdiomaHttpService : IIdiomaHttpService
    {
        public Task<int> AddAsync(IdiomaViewModel idiomaViewModel)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(IdiomaViewModel idiomaViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IdiomaViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(IdiomaViewModel idiomaViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
