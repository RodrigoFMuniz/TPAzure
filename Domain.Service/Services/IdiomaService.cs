using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class IdiomaService : IIdiomaService
    {
        private readonly IIdiomaRepository _idiomaRepository;

        public IdiomaService(IIdiomaRepository idiomaRepository)
        {
            _idiomaRepository = idiomaRepository;
        }

        public async Task<int> AddAsync(IdiomaEntity idiomaEntity)
        {
            return await _idiomaRepository.AddAsync(idiomaEntity);
        }

        public async Task EditAsync(IdiomaEntity idiomaEntity)
        {
            await _idiomaRepository.EditAsync(idiomaEntity);
        }

        public async Task<IEnumerable<IdiomaEntity>> GetAllAsync(string search)
        {
            return await _idiomaRepository.GetAllAsync(search);
        }

        public async Task<IdiomaEntity> GetByIdAsync(int id)
        {
            return await _idiomaRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(IdiomaEntity idiomaEntity)
        {
            await _idiomaRepository.RemoveAsync(idiomaEntity);
        }
    }
}
