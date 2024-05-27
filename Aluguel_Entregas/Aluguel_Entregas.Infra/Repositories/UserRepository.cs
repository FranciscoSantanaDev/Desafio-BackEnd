using Aluguel_Entregas.Domain.Contracts.Repository.Courier;
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
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<User> _dbSet;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.User;
        }
       
        public async Task<User> GetUser(string username)
        {
              return await _dbSet.Include(u=>u.Courier).FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
