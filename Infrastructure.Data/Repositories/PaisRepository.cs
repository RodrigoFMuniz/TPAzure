using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PaisRepository : IPaisRepository
    {

        private readonly PaisIdiomaContext _paisIdiomaContext;

        public PaisRepository(PaisIdiomaContext paisIdiomaContext)
        {
            _paisIdiomaContext = paisIdiomaContext;
        }

        public async Task<int> AddAsync(PaisEntity paisEntity)
        {
            var entityEntry = await _paisIdiomaContext.Paises.AddAsync(paisEntity);
            await _paisIdiomaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(PaisEntity paisEntity)
        {
            _paisIdiomaContext.Paises.Update(paisEntity);
            await _paisIdiomaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PaisEntity>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _paisIdiomaContext.Paises;
            }

            return _paisIdiomaContext.Paises.Where(x => x.Nome.Contains(search));
        }

        public async Task<PaisEntity> GetByIdAsync(int id)
        {
            return await _paisIdiomaContext.Paises.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(PaisEntity paisEntity)
        {
            var autorToRemove = await GetByIdAsync(paisEntity.Id);
            _paisIdiomaContext.Paises.Remove(autorToRemove);
            await _paisIdiomaContext.SaveChangesAsync();
        }
    }
}
