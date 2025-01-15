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
    internal class documentRepository : IdocumentRepository
    {
        private readonly documentDbContext _dbContext;
        public documentRepository(documentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<document>> GetAll() => await _dbContext.documents.ToListAsync();

    }
}
