using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Watosik.Application.Scoring
{
    public static class PullUpsScoring
    {
        public static float GetPoints(string category, string gender, int reps)
        {
            var scoringTable = gender == "Male" ? Male : Female;

            if (!scoringTable.ContainsKey(category))
            {
                throw new ArgumentException($"Category '{category}' does not exist.", nameof(category));
            }

            var categoryTable = scoringTable[category];
            var closestElement = categoryTable
                .OrderBy(s => Math.Abs(s.Reps - reps))
                .FirstOrDefault();

            return closestElement.Points;
        }


        public static readonly Dictionary<string, List<(int Reps, float Points)>> Male = new()
        {
            { "do 20", new List<(int Reps, float Points)>
                {
                    (18, 21), (17, 21), (16, 20), (15, 19.6f), (14, 19.2f),
                    (13, 18.8f), (12, 18.4f), (11, 18f), (10, 17.6f), (9, 17.2f),
                    (8, 16.8f), (7, 16.4f), (6, 16f), (5, 15.6f), (4, 15.2f),
                    (3, 14.8f), (2, 14.4f), (1, 14f)
                }
            },
            { "21-25", new List<(int Reps, float Points)>
                {
                    (18, 21), (17, 20.8f), (16, 20.4f), (15, 20f), (14, 19.6f),
                    (13, 19.2f), (12, 18.8f), (11, 18.4f), (10, 18f), (9, 17.6f),
                    (8, 17.2f), (7, 16.8f), (6, 16.4f), (5, 16f), (4, 15.6f),
                    (3, 15.2f), (2, 14.8f), (1, 14.4f)
                }
            },
            { "26-30", new List<(int Reps, float Points)>
                {
                    (18, 21), (17, 20.4f), (16, 20f), (15, 19.6f), (14, 19.2f),
                    (13, 18.8f), (12, 18.4f), (11, 18f), (10, 17.6f), (9, 17.2f),
                    (8, 16.8f), (7, 16.4f), (6, 16f), (5, 15.6f), (4, 15.2f),
                    (3, 14.8f), (2, 14.4f), (1, 14f)
                }
            }
        };

        // Scoring table for women based on age categories
        public static readonly Dictionary<string, List<(int Reps, float Points)>> Female = new()
        {
            // Age category: "do 20"
            { "do 20", new List<(int Reps, float Points)>
                {
                    (8, 21), (7, 20.2f), (6, 19.4f), (5, 21),
                    (4, 20.2f), (3, 19.4f), (2, 18.6f), (1, 17.8f)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(int Reps, float Points)>
                {
                    (8, 21), (7, 20.2f), (6, 19.4f), (5, 18.6f),
                    (4, 17.8f), (3, 17), (2, 16.2f), (1, 15.4f)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(int Reps, float Points)>
                {
                    (8, 21), (7, 21), (6, 20.2f), (5, 19.4f),
                    (4, 18.6f), (3, 17.8f), (2, 17), (1, 16.2f)
                }
            }
        };
    }
}
