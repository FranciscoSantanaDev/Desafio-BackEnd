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
    internal class CourierRepository : ICourierRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Courier> _dbSet;

        public CourierRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Courier;
        }

        public async Task<(bool sucess, string message)> Create(Courier courier)
        {
            try
            {
                await _dbSet.AddAsync(courier);
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

        public async Task Delete(Courier courier)
        {
             _dbSet.Remove(courier);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(Courier courier)
        {
            _dbSet.Update(courier);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
