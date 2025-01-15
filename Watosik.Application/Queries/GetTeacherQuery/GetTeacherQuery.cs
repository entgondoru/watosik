using MediatR;
using Watosik.Domain.Entities;

namespace Watosik.Application.Queries.GetTeacherQuery
{
    public class GetTeachersQuery : IRequest<List<Teacher>>
    {
        public string SearchTerm { get; set; }
    }
}

