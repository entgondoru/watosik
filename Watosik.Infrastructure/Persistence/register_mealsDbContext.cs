using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;

namespace Watosik.Infrastructure.Persistence
{
    public class register_mealsDbContext : DbContext
    {
        public register_mealsDbContext(DbContextOptions<register_mealsDbContext> options) : base(options) { }
        public DbSet<register_meals> current_register_meals_view { get; set; }
    }
}
