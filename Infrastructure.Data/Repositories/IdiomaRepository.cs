using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class IdiomaRepository : IIdiomaRepository
    {

        private readonly PaisIdiomaContext _paisIdiomaContext;

        public IdiomaRepository(PaisIdiomaContext paisIdiomaContext)
        {
            _paisIdiomaContext = paisIdiomaContext;
        }

        public async Task<int> AddAsync(IdiomaEntity idiomaEntity)
        {
            var entityEntry = await _paisIdiomaContext.Idiomas.AddAsync(idiomaEntity);
            await _paisIdiomaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(IdiomaEntity idiomaEntity)
        {
            var idiomaToUpdate = await GetByIdAsync(idiomaEntity.Id);
            _paisIdiomaContext
                 .Entry(idiomaToUpdate)
                    .CurrentValues
                    .SetValues(idiomaEntity);
           
            await _paisIdiomaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IdiomaEntity>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _paisIdiomaContext.Idiomas;
            }

            return _paisIdiomaContext.Idiomas.Where(x => x.NomeIdioma.Contains(search));
        }

        public async Task<IdiomaEntity> GetByIdAsync(int id)
        {
            return await _paisIdiomaContext.Idiomas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(IdiomaEntity idiomaEntity)
        {
            var idiomaToRemove = await GetByIdAsync(idiomaEntity.Id);
            _paisIdiomaContext.Idiomas.Remove(idiomaToRemove);
            await _paisIdiomaContext.SaveChangesAsync();
        }
    }
}
