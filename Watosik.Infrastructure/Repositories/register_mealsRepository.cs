using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;
using Watosik.Domain.Interfaces;
using Watosik.Infrastructure.Persistence;

namespace Watosik.Infrastructure.Repositories
{
    internal class register_mealsRepository : Iregister_mealsRepository
    {
        private readonly register_mealsDbContext _dbContext;
        public register_mealsRepository(register_mealsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<register_meals>> GetAll() => await _dbContext.current_register_meals_view.ToListAsync();

    }
}
