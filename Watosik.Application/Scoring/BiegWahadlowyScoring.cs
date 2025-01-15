using System;
using System.Collections.Generic;

namespace Watosik.Application.Scoring
{
    public static class BiegWahadlowyScoring
    {
        public static float GetPoints(string category, string gender, float time)
        {
            var scoringTable = gender == "Male" ? Male : Female;

            if (!scoringTable.ContainsKey(category))
            {
                throw new ArgumentException($"Category '{category}' does not exist.", nameof(category));
            }

            var categoryTable = scoringTable[category];
            var closestElement = categoryTable
                .OrderBy(s => Math.Abs(s.Time - time))
                .FirstOrDefault();

            return closestElement.Points;
        }

        // Scoring table for men based on age categories
        public static readonly Dictionary<string, List<(float Time, float Points)>> Male = new()
{
    // Age category: "do 20"
    { "do 20", new List<(float Time, float Points)>
        {
            (28.6f, 19f), (28.7f, 19f), (28.8f, 18f), (28.9f, 18f),
            (29.0f, 19f), (29.1f, 18f), (29.2f, 18f), (29.3f, 17f),
            (29.4f, 17f), (29.5f, 16f), (29.6f, 16f), (29.7f, 15f),
            (29.8f, 15f), (29.9f, 14f), (30.0f, 14f), (30.1f, 13f),
            (30.2f, 13f), (30.3f, 12f), (30.4f, 12f), (30.5f, 11f),
            (30.6f, 11f), (30.7f, 10f), (30.8f, 10f), (30.9f, 9f),
            (31.0f, 9f), (31.1f, 8f), (31.2f, 8f), (31.3f, 7f),
            (31.4f, 7f), (31.5f, 6f), (31.6f, 6f), (31.7f, 5f),
            (31.8f, 5f), (31.9f, 4f), (32.0f, 4f), (32.1f, 3f),
            (32.2f, 3f), (32.3f, 2f), (32.4f, 2f), (32.5f, 1f),
            (32.6f, 1f), (32.7f, 0f), (32.8f, 0f)
        }
    },

    // Age category: "21-25"
    { "21-25", new List<(float Time, float Points)>
        {
            (28.6f, 19f), (28.7f, 18f), (28.8f, 18f), (28.9f, 17f),
            (29.0f, 17f), (29.1f, 16f), (29.2f, 16f), (29.3f, 15f),
            (29.4f, 15f), (29.5f, 14f), (29.6f, 14f), (29.7f, 13f),
            (29.8f, 13f), (29.9f, 12f), (30.0f, 12f), (30.1f, 11f),
            (30.2f, 11f), (30.3f, 10f), (30.4f, 10f), (30.5f, 9f),
            (30.6f, 9f), (30.7f, 8f), (30.8f, 8f), (30.9f, 7f),
            (31.0f, 7f), (31.1f, 6f), (31.2f, 6f), (31.3f, 5f),
            (31.4f, 5f), (31.5f, 4f), (31.6f, 4f), (31.7f, 3f),
            (31.8f, 3f), (31.9f, 2f), (32.0f, 2f), (32.1f, 1f),
            (32.2f, 1f), (32.3f, 0f), (32.4f, 0f)
        }
    },

    // Age category: "26-30"
    { "26-30", new List<(float Time, float Points)>
        {
            (28.6f, 19f), (28.7f, 18f), (28.8f, 18f), (28.9f, 17f),
            (29.0f, 17f), (29.1f, 16f), (29.2f, 16f), (29.3f, 15f),
            (29.4f, 15f), (29.5f, 14f), (29.6f, 14f), (29.7f, 13f),
            (29.8f, 13f), (29.9f, 12f), (30.0f, 12f), (30.1f, 11f),
            (30.2f, 11f), (30.3f, 10f), (30.4f, 10f), (30.5f, 9f),
            (30.6f, 9f), (30.7f, 8f), (30.8f, 8f), (30.9f, 7f),
            (31.0f, 7f), (31.1f, 6f), (31.2f, 6f), (31.3f, 5f),
            (31.4f, 5f), (31.5f, 4f), (31.6f, 4f), (31.7f, 3f),
            (31.8f, 3f), (31.9f, 2f), (32.0f, 2f), (32.1f, 1f),
            (32.2f, 1f), (32.3f, 0f), (32.4f, 0f)
        }
    }
};


        // Scoring table for women based on age categories
        public static readonly Dictionary<string, List<(float Time, float Points)>> Female = new()
        {
            // Age category: "do 20"
            { "do 20", new List<(float Time, float Points)>
                {
                    (30.7f, 19), (30.8f, 18.6f), (30.9f, 18.2f), (31.0f, 17.8f),
                    (31.1f, 17.4f), (31.2f, 17), (31.3f, 16.6f), (31.4f, 16.2f),
                    (31.5f, 15.8f), (31.6f, 15.4f), (31.7f, 15), (31.8f, 14.6f),
                    (31.9f, 14.2f), (32.0f, 13.8f), (32.1f, 13.4f), (32.2f, 13f),
                    (32.3f, 12.6f), (32.4f, 12.2f), (32.5f, 11.8f), (32.6f, 11.4f),
                    (32.7f, 11), (32.8f, 10.6f), (32.9f, 10.2f), (33.0f, 9.8f),
                    (33.1f, 9.4f), (33.2f, 9), (33.3f, 8.6f), (33.4f, 8.2f),
                    (33.5f, 7.8f), (33.6f, 7.4f), (33.7f, 7), (33.8f, 6.6f),
                    (33.9f, 6.2f), (34.0f, 5.8f), (34.1f, 5.4f), (34.2f, 5),
                    (34.3f, 4.6f), (34.4f, 4.2f), (34.5f, 3.8f), (34.6f, 3.4f),
                    (34.7f, 3), (34.8f, 2.6f), (34.9f, 2.2f), (35.0f, 1.8f),
                    (35.1f, 1.4f), (35.2f, 1), (35.3f, 0.6f), (35.4f, 0.2f), (35.5f, 0)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(float Time, float Points)>
                {
                    (30.7f, 19), (30.8f, 18.6f), (30.9f, 18.2f), (31.0f, 17.8f),
                    (31.1f, 17.4f), (31.2f, 17), (31.3f, 16.6f), (31.4f, 16.2f),
                    (31.5f, 15.8f), (31.6f, 15.4f), (31.7f, 15), (31.8f, 14.6f),
                    (31.9f, 14.2f), (32.0f, 13.8f), (32.1f, 13.4f), (32.2f, 13f),
                    (32.3f, 12.6f), (32.4f, 12.2f), (32.5f, 11.8f), (32.6f, 11.4f),
                    (32.7f, 11), (32.8f, 10.6f), (32.9f, 10.2f), (33.0f, 9.8f),
                    (33.1f, 9.4f), (33.2f, 9), (33.3f, 8.6f), (33.4f, 8.2f),
                    (33.5f, 7.8f), (33.6f, 7.4f), (33.7f, 7), (33.8f, 6.6f),
                    (33.9f, 6.2f), (34.0f, 5.8f), (34.1f, 5.4f), (34.2f, 5),
                    (34.3f, 4.6f), (34.4f, 4.2f), (34.5f, 3.8f), (34.6f, 3.4f),
                    (34.7f, 3), (34.8f, 2.6f), (34.9f, 2.2f), (35.0f, 1.8f),
                    (35.1f, 1.4f), (35.2f, 1), (35.3f, 0.6f), (35.4f, 0.2f), (35.5f, 0)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(float Time, float Points)>
                {
                    (30.7f, 19), (30.8f, 18.6f), (30.9f, 18.2f), (31.0f, 17.8f),
                    (31.1f, 17.4f), (31.2f, 17), (31.3f, 16.6f), (31.4f, 16.2f),
                    (31.5f, 15.8f), (31.6f, 15.4f), (31.7f, 15), (31.8f, 14.6f),
                    (31.9f, 14.2f), (32.0f, 13.8f), (32.1f, 13.4f), (32.2f, 13f),
                    (32.3f, 12.6f), (32.4f, 12.2f), (32.5f, 11.8f), (32.6f, 11.4f),
                    (32.7f, 11), (32.8f, 10.6f), (32.9f, 10.2f), (33.0f, 9.8f),
                    (33.1f, 9.4f), (33.2f, 9), (33.3f, 8.6f), (33.4f, 8.2f),
                    (33.5f, 7.8f), (33.6f, 7.4f), (33.7f, 7), (33.8f, 6.6f),
                    (33.9f, 6.2f), (34.0f, 5.8f), (34.1f, 5.4f), (34.2f, 5),
                    (34.3f, 4.6f), (34.4f, 4.2f), (34.5f, 3.8f), (34.6f, 3.4f),
                    (34.7f, 3), (34.8f, 2.6f), (34.9f, 2.2f), (35.0f, 1.8f),
                    (35.1f, 1.4f), (35.2f, 1), (35.3f, 0.6f), (35.4f, 0.2f), (35.5f, 0)
                }
            }
        };

    }
}
