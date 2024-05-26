using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Infra.Repositories
{
    internal class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Motorcycle> _dbSet;

        public MotorcycleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Motorcycles;
        }

        public async Task<(bool sucess, string message)> Create(Motorcycle motorcycle)
        {
            try
            {
                await _dbSet.AddAsync(motorcycle);
                await _applicationDbContext.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (false, ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                return (false, ex.InnerException?.Message);
            }
           
        }

        public async Task Delete(Motorcycle motorcycle)
        {
             _dbSet.Remove(motorcycle);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(Motorcycle motorcycle)
        {
            _dbSet.Update(motorcycle);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
