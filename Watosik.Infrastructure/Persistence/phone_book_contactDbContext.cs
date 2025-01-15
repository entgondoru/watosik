using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain;

namespace Watosik.Infrastructure.Persistence
{
    public class phone_book_contactDbContext : DbContext
    {

        public phone_book_contactDbContext(DbContextOptions<phone_book_contactDbContext> options) : base(options) { }
        public DbSet<phone_book_contact> phone_book_contacts { get; set; }

    }
}
