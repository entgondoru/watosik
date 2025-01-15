using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;

namespace Watosik.Infrastructure.Persistence
{
    public class mealDbContext : DbContext
    {

        public mealDbContext(DbContextOptions<mealDbContext> options) : base(options) { }
        public DbSet<meal> meal { get; set; }

    }
}
