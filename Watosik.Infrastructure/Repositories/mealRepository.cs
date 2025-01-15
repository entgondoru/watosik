using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;
using Watosik.Domain.Interfaces;
using Watosik.Infrastructure.Persistence;

namespace Watosik.Infrastructure.Repositories
{
    internal class mealRepository : ImealRepository
    {
        private readonly mealDbContext _dbContext;
        public mealRepository(mealDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<meal>> GetAll() => await _dbContext.meal.ToListAsync();

    }
}
