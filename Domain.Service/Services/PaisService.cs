using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class PaisService : IPaisService
    {

        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public async Task<int> AddAsync(PaisEntity paisEntity)
        {
            return await _paisRepository.AddAsync(paisEntity);
        }

        public async Task EditAsync(PaisEntity paisEntity)
        {
            await _paisRepository.EditAsync(paisEntity);
        }

        public async Task<IEnumerable<PaisEntity>> GetAllAsync(string search)
        {
            return await _paisRepository.GetAllAsync(search);
        }

        public async Task<PaisEntity> GetByIdAsync(int id)
        {
            return await _paisRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(PaisEntity paisEntity)
        {
            await _paisRepository.RemoveAsync(paisEntity);
        }
    }
}
