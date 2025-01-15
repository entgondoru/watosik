using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Interfaces
{
    public interface IdocumentRepository
    {
        //Task Create(document documentUnit);
        Task<IEnumerable<document>> GetAll();
    }
}
