using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Application.DataTransferObjects;
using Watosik.Domain;

namespace Watosik.Application.Queries.GetAllRegisterMeals
{
    public class GetAllRegisterMealsQuery : IRequest<IEnumerable<register_mealsDTO>>
    {
    }
}
