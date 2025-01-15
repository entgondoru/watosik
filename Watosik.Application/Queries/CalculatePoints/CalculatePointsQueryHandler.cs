using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Watosik.Application.Queries.CalculatePoints;
using Watosik.Application.Scoring;
using Watosik.Domain.Entities;


namespace Watosik.Application.Queries
{
    public class CalculatePointsQueryHandler : IRequestHandler<CalculatePointsQuery, CalculatePointsResponse>
    {
        public Task<CalculatePointsResponse> Handle(CalculatePointsQuery request, CancellationToken cancellationToken)
        {
            int marszobiegPoints = 0;
            int plywaniePoints = 0;
            int pushUpsPoints = 0;
            int pullUpsPoints = 0;
            int biegWahadlowyPoints = 0;
            int biegZygzakiemPoints = 0;
            int sklonyPoints = 0;

            // Marszobieg lub pływanie
            if (request.MarszobiegTime > 0)
            {
                marszobiegPoints = MarszobiegScoring.GetPoints(request.AgeCategory, request.Gender, request.MarszobiegTime);
            }
            if (request.PlywanieDistance > 0)
            {
                plywaniePoints = SwimmingScoring.GetPoints(request.AgeCategory, request.Gender, request.PlywanieDistance);
            }

            // Pompki lub podciąganie
            if (request.PushUps > 0)
            {
                pushUpsPoints = (int)PushUpsScoring.GetPoints(request.AgeCategory, request.Gender, request.PushUps);
            }
            if (request.PullUps > 0)
            {
                pullUpsPoints = (int)PullUpsScoring.GetPoints(request.AgeCategory, request.Gender, request.PullUps);
            }

            // Bieg wahadłowy lub bieg zygzakiem
            if (request.BiegWahadlowyTime > 0)
            {
                biegWahadlowyPoints = (int)BiegWahadlowyScoring.GetPoints(request.AgeCategory, request.Gender, request.BiegWahadlowyTime);
            }
            if (request.BiegZygzakiemTime > 0)
            {
                biegZygzakiemPoints = (int)BiegZygzakiemScoring.GetPoints(request.AgeCategory, request.Gender, request.BiegZygzakiemTime);
            }

            // Skłony
            if (request.SklonyReps > 0)
            {
                sklonyPoints = (int)SitUpsScoring.GetPoints(request.AgeCategory, request.Gender, request.SklonyReps);
            }

            // Suma punktów
            int totalPoints = marszobiegPoints + plywaniePoints + pushUpsPoints + pullUpsPoints + biegWahadlowyPoints + biegZygzakiemPoints + sklonyPoints;

            // Ocena końcowa
            string grade = GradeThresholds
                .FirstOrDefault(g => totalPoints >= g.MinPoints && totalPoints <= g.MaxPoints)?.Grade ?? "Niedostateczna";

            return Task.FromResult(new CalculatePointsResponse
            {
                MarszobiegPoints = marszobiegPoints,
                PlywaniePoints = plywaniePoints,
                PushUpsPoints = pushUpsPoints,
                PullUpsPoints = pullUpsPoints,
                BiegWahadlowyPoints = biegWahadlowyPoints,
                BiegZygzakiemPoints = biegZygzakiemPoints,
                SklonyPoints = sklonyPoints,
                TotalPoints = totalPoints,
                Grade = grade
            });
        }


        // Grade thresholds (adjust values as needed)
        private static readonly List<GradeThreshold> GradeThresholds = new()
        {
            new GradeThreshold { Grade = "Bardzo dobra", MinPoints = 80, MaxPoints = 100 },
            new GradeThreshold { Grade = "Dobra", MinPoints = 68, MaxPoints = 79 },
            new GradeThreshold { Grade = "Dostateczna", MinPoints = 60, MaxPoints = 67 },
            new GradeThreshold { Grade = "Niedostateczna", MinPoints = 0, MaxPoints = 59 }
        };
    }
}
