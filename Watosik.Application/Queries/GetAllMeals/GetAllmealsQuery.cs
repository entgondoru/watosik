using MediatR;
using Watosik.Application.DataTransferObjects;

namespace Watosik.Application.Queries.GetAllDocuments
{
    public class GetAllmealsQuery : IRequest<IEnumerable<mealDto>>
    {

    }
}
