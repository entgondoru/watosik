using MediatR;
using Watosik.Application.Teachers;
using Watosik.Domain.Entities;

namespace Watosik.Application.Queries.GetTeacherQuery
{
    public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, List<Teacher>>
    {
        public Task<List<Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = TeacherData.Teachers;

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                teachers = teachers.Where(t =>
                    t.FullName.ToLower().Contains(searchTerm) ||
                    t.RoomNumber.ToLower().Contains(searchTerm) ||
                    t.Phone.ToLower().Contains(searchTerm) ||
                    t.Monday.ToLower().Contains(searchTerm) ||
                    t.Tuesday.ToLower().Contains(searchTerm) ||
                    t.Wednesday.ToLower().Contains(searchTerm) ||
                    t.Thursday.ToLower().Contains(searchTerm) ||
                    t.Friday.ToLower().Contains(searchTerm)
                ).ToList();
            }

            return Task.FromResult(teachers);
        }
    }
}

