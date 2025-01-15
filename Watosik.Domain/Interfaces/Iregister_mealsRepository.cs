using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Interfaces
{
    public interface Iregister_mealsRepository
    {
        Task<IEnumerable<register_meals>> GetAll();
    }
}
