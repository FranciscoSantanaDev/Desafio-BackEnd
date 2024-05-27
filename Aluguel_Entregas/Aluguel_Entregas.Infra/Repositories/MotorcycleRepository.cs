using Aluguel_Entregas.Domain.Contracts.Repository.Motorcycle;
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

        public async Task<(bool sucess, string message)> Delete(Motorcycle motorcycle)
        {
            try
            {
                _dbSet.Remove(motorcycle);
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

        public async Task<IEnumerable<Motorcycle>> Get(string? plate)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(plate))
            {
                query = query.Where(c => c.Plate == plate);
            }

            return await query.ToListAsync();
        }

        public async Task<Motorcycle> Get(Guid Id)
        {
            return await _dbSet.FirstAsync(m=>m.Id ==Id);
        }
        public async Task<Motorcycle> GetAvailable()
        {
            return await _dbSet.Include(m=>m.Rent).FirstAsync(m=>m.Rent == null);
        }

        public async Task<(bool sucess, string message)> Update(Motorcycle motorcycle)
        {
            try
            {
                _dbSet.Update(motorcycle);
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
    }
}
