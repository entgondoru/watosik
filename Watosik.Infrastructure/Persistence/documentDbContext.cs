using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;

namespace Watosik.Infrastructure.Persistence
{
    public class documentDbContext : DbContext
    {

        public documentDbContext(DbContextOptions<documentDbContext> options) : base(options) { }
        public DbSet<document> documents { get; set; }

    }
}
