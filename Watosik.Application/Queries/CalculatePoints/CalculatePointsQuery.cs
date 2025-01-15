using MediatR;
using System.Collections.Generic;
using Watosik.Domain.Entities;

namespace Watosik.Application.Queries.CalculatePoints
{
    public class CalculatePointsQuery : IRequest<CalculatePointsResponse>
    {
        public string Gender { get; set; }
        public string AgeCategory { get; set; }
        public float MarszobiegTime { get; set; }
        public int PushUps { get; set; }
        public float BiegWahadlowyTime { get; set; }
        public float BiegZygzakiemTime { get; set; }
        public int SklonyReps { get; set; }
        public int PlywanieDistance { get; set; }
        public int PullUps { get; set; }
    }

    public class CalculatePointsResponse
    {
        public int MarszobiegPoints { get; set; }
        public int PushUpsPoints { get; set; }
        public int PullUpsPoints { get; set; }
        public int BiegWahadlowyPoints { get; set; }
        public int BiegZygzakiemPoints { get; set; }
        public int SklonyPoints { get; set; }
        public int PlywaniePoints { get; set; }
        public int TotalPoints { get; set; }
        public string Grade { get; set; }
    }
}
