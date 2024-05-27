using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Repository.Rent;
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
    internal class RentRepository : IRentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Rent> _dbSet;

        public RentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Rents;
        }

        public async Task<(bool sucess, string message)> Create(Rent rent)
        {
            try
            {
                await _dbSet.AddAsync(rent);
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

        public async Task<(bool sucess, string message)> Update(Rent rent)
        {
            try
            {
                _dbSet.Update(rent);
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
