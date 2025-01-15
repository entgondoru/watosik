using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Interfaces
{
    public interface Iphone_book_contactRepository
    {
        Task Create(phone_book_contact contact);
        Task<IEnumerable<phone_book_contact>> GetAll();
    }
}
