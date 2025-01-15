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
    internal class phone_book_contactRepository : Iphone_book_contactRepository
    {
        private readonly phone_book_contactDbContext _dbContext;
        public phone_book_contactRepository(phone_book_contactDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(phone_book_contact contact)
        {
            _dbContext.Add(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<phone_book_contact>> GetAll() => await _dbContext.phone_book_contacts.ToListAsync();
    }
}
