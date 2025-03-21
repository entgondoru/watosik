﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Watosik.Application.Scoring
{
    public static class BiegZygzakiemScoring
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
                    (22.6f, 19), (22.7f, 19), (22.8f, 19), (22.9f, 19),
                    (23.0f, 18), (23.1f, 18), (23.2f, 18), (23.3f, 17),
                    (23.4f, 17), (23.5f, 17), (23.6f, 16), (23.7f, 16),
                    (23.8f, 16), (23.9f, 15), (24.0f, 15), (24.1f, 15),
                    (24.2f, 14), (24.3f, 14), (24.4f, 14), (24.5f, 13),
                    (24.6f, 13), (24.7f, 13), (24.8f, 12), (24.9f, 12),
                    (25.0f, 12), (25.1f, 11), (25.2f, 11), (25.3f, 11),
                    (25.4f, 10), (25.5f, 10), (25.6f, 10), (25.7f, 9),
                    (25.8f, 9), (25.9f, 9), (26.0f, 8), (26.1f, 8),
                    (26.2f, 8), (26.3f, 7), (26.4f, 7), (26.5f, 7),
                    (26.6f, 6), (26.7f, 6), (26.8f, 6), (26.9f, 5),
                    (27.0f, 5), (27.1f, 5), (27.2f, 4), (27.3f, 4),
                    (27.4f, 4), (27.5f, 3), (27.6f, 3), (27.7f, 3),
                    (27.8f, 2), (27.9f, 2), (28.0f, 2), (28.1f, 1),
                    (28.2f, 1), (28.3f, 1), (28.4f, 0), (28.5f, 0)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(float Time, float Points)>
                {
                    (22.6f, 19), (22.7f, 18.7f), (22.8f, 18.4f), (22.9f, 18.1f),
                    (23.0f, 18), (23.1f, 17.8f), (23.2f, 17.6f), (23.3f, 17.4f),
                    (23.4f, 17.2f), (23.5f, 17), (23.6f, 16.8f), (23.7f, 16.6f),
                    (23.8f, 16.4f), (23.9f, 16.2f), (24.0f, 16), (24.1f, 15.8f),
                    (24.2f, 15.6f), (24.3f, 15.4f), (24.4f, 15.2f), (24.5f, 15),
                    (24.6f, 14.8f), (24.7f, 14.6f), (24.8f, 14.4f), (24.9f, 14.2f),
                    (25.0f, 14), (25.1f, 13.8f), (25.2f, 13.6f), (25.3f, 13.4f),
                    (25.4f, 13.2f), (25.5f, 13), (25.6f, 12.8f), (25.7f, 12.6f),
                    (25.8f, 12.4f), (25.9f, 12.2f), (26.0f, 12), (26.1f, 11.8f),
                    (26.2f, 11.6f), (26.3f, 11.4f), (26.4f, 11.2f), (26.5f, 11),
                    (26.6f, 10.8f), (26.7f, 10.6f), (26.8f, 10.4f), (26.9f, 10.2f),
                    (27.0f, 10), (27.1f, 9.8f), (27.2f, 9.6f), (27.3f, 9.4f),
                    (27.4f, 9.2f), (27.5f, 9), (27.6f, 8.8f), (27.7f, 8.6f),
                    (27.8f, 8.4f), (27.9f, 8.2f), (28.0f, 8), (28.1f, 7.8f),
                    (28.2f, 7.6f), (28.3f, 7.4f), (28.4f, 7.2f), (28.5f, 7)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(float Time, float Points)>
                {
                    (22.6f, 19), (22.7f, 18.7f), (22.8f, 18.4f), (22.9f, 18.1f),
                    (23.0f, 18), (23.1f, 17.8f), (23.2f, 17.6f), (23.3f, 17.4f),
                    (23.4f, 17.2f), (23.5f, 17), (23.6f, 16.8f), (23.7f, 16.6f),
                    (23.8f, 16.4f), (23.9f, 16.2f), (24.0f, 16), (24.1f, 15.8f),
                    (24.2f, 15.6f), (24.3f, 15.4f), (24.4f, 15.2f), (24.5f, 15),
                    (24.6f, 14.8f), (24.7f, 14.6f), (24.8f, 14.4f), (24.9f, 14.2f),
                    (25.0f, 14), (25.1f, 13.8f), (25.2f, 13.6f), (25.3f, 13.4f),
                    (25.4f, 13.2f), (25.5f, 13), (25.6f, 12.8f), (25.7f, 12.6f),
                    (25.8f, 12.4f), (25.9f, 12.2f), (26.0f, 12), (26.1f, 11.8f),
                    (26.2f, 11.6f), (26.3f, 11.4f), (26.4f, 11.2f), (26.5f, 11),
                    (26.6f, 10.8f), (26.7f, 10.6f), (26.8f, 10.4f), (26.9f, 10.2f),
                    (27.0f, 10), (27.1f, 9.8f), (27.2f, 9.6f), (27.3f, 9.4f),
                    (27.4f, 9.2f), (27.5f, 9), (27.6f, 8.8f), (27.7f, 8.6f),
                    (27.8f, 8.4f), (27.9f, 8.2f), (28.0f, 8), (28.1f, 7.8f),
                    (28.2f, 7.6f), (28.3f, 7.4f), (28.4f, 7.2f), (28.5f, 7)
                }
            }
        };
        // Scoring table for women based on age categories
        public static readonly Dictionary<string, List<(float Time, float Points)>> Female = new()
        {
            // Age category: "do 20"
            { "do 20", new List<(float Time, float Points)>
                {
                    (25.0f, 19), (25.1f, 19), (25.2f, 18.7f), (25.3f, 18.4f),
                    (25.4f, 18.1f), (25.5f, 18), (25.6f, 17.8f), (25.7f, 17.5f),
                    (25.8f, 17.2f), (25.9f, 16.9f), (26.0f, 16.6f), (26.1f, 16.3f),
                    (26.2f, 16), (26.3f, 15.7f), (26.4f, 15.4f), (26.5f, 15.1f),
                    (26.6f, 14.8f), (26.7f, 14.5f), (26.8f, 14.2f), (26.9f, 13.9f),
                    (27.0f, 13.6f), (27.1f, 13.3f), (27.2f, 13), (27.3f, 12.7f),
                    (27.4f, 12.4f), (27.5f, 12.1f), (27.6f, 11.8f), (27.7f, 11.5f),
                    (27.8f, 11.2f), (27.9f, 10.9f), (28.0f, 10.6f), (28.1f, 10.3f),
                    (28.2f, 10), (28.3f, 9.7f), (28.4f, 9.4f), (28.5f, 9.1f),
                    (28.6f, 8.8f), (28.7f, 8.5f), (28.8f, 8.2f), (28.9f, 7.9f),
                    (29.0f, 7.6f), (29.1f, 7.3f), (29.2f, 7), (29.3f, 6.7f),
                    (29.4f, 6.4f), (29.5f, 6.1f), (29.6f, 5.8f), (29.7f, 5.5f),
                    (29.8f, 5.2f), (29.9f, 4.9f), (30.0f, 4.6f), (30.1f, 4.3f),
                    (30.2f, 4.0f), (30.3f, 3.7f), (30.4f, 3.4f), (30.5f, 3.1f),
                    (30.6f, 2.8f), (30.7f, 2.5f), (30.8f, 2.2f), (30.9f, 1.9f),
                    (31.0f, 1.6f), (31.1f, 1.3f), (31.2f, 1.0f), (31.3f, 0.7f),
                    (31.4f, 0.4f), (31.5f, 0.1f)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(float Time, float Points)>
                {
                    (25.0f, 19), (25.1f, 18.7f), (25.2f, 18.4f), (25.3f, 18.1f),
                    (25.4f, 18), (25.5f, 17.8f), (25.6f, 17.5f), (25.7f, 17.2f),
                    (25.8f, 16.9f), (25.9f, 16.6f), (26.0f, 16.3f), (26.1f, 16),
                    (26.2f, 15.7f), (26.3f, 15.4f), (26.4f, 15.1f), (26.5f, 14.8f),
                    (26.6f, 14.5f), (26.7f, 14.2f), (26.8f, 13.9f), (26.9f, 13.6f),
                    (27.0f, 13.3f), (27.1f, 13), (27.2f, 12.7f), (27.3f, 12.4f),
                    (27.4f, 12.1f), (27.5f, 11.8f), (27.6f, 11.5f), (27.7f, 11.2f),
                    (27.8f, 10.9f), (27.9f, 10.6f), (28.0f, 10.3f), (28.1f, 10),
                    (28.2f, 9.7f), (28.3f, 9.4f), (28.4f, 9.1f), (28.5f, 8.8f),
                    (28.6f, 8.5f), (28.7f, 8.2f), (28.8f, 7.9f), (28.9f, 7.6f),
                    (29.0f, 7.3f), (29.1f, 7), (29.2f, 6.7f), (29.3f, 6.4f),
                    (29.4f, 6.1f), (29.5f, 5.8f), (29.6f, 5.5f), (29.7f, 5.2f),
                    (29.8f, 4.9f), (29.9f, 4.6f), (30.0f, 4.3f), (30.1f, 4.0f),
                    (30.2f, 3.7f), (30.3f, 3.4f), (30.4f, 3.1f), (30.5f, 2.8f),
                    (30.6f, 2.5f), (30.7f, 2.2f), (30.8f, 1.9f), (30.9f, 1.6f),
                    (31.0f, 1.3f), (31.1f, 1.0f), (31.2f, 0.7f), (31.3f, 0.4f), (31.4f, 0.1f)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(float Time, float Points)>
                {
                    (25.0f, 19), (25.1f, 18.7f), (25.2f, 18.4f), (25.3f, 18.1f),
                    (25.4f, 18), (25.5f, 17.8f), (25.6f, 17.5f), (25.7f, 17.2f),
                    (25.8f, 16.9f), (25.9f, 16.6f), (26.0f, 16.3f), (26.1f, 16),
                    (26.2f, 15.7f), (26.3f, 15.4f), (26.4f, 15.1f), (26.5f, 14.8f),
                    (26.6f, 14.5f), (26.7f, 14.2f), (26.8f, 13.9f), (26.9f, 13.6f),
                    (27.0f, 13.3f), (27.1f, 13), (27.2f, 12.7f), (27.3f, 12.4f),
                    (27.4f, 12.1f), (27.5f, 11.8f), (27.6f, 11.5f), (27.7f, 11.2f),
                    (27.8f, 10.9f), (27.9f, 10.6f), (28.0f, 10.3f), (28.1f, 10),
                    (28.2f, 9.7f), (28.3f, 9.4f), (28.4f, 9.1f), (28.5f, 8.8f),
                    (28.6f, 8.5f), (28.7f, 8.2f), (28.8f, 7.9f), (28.9f, 7.6f),
                    (29.0f, 7.3f), (29.1f, 7), (29.2f, 6.7f), (29.3f, 6.4f),
                    (29.4f, 6.1f), (29.5f, 5.8f), (29.6f, 5.5f), (29.7f, 5.2f),
                    (29.8f, 4.9f), (29.9f, 4.6f), (30.0f, 4.3f), (30.1f, 4.0f),
                    (30.2f, 3.7f), (30.3f, 3.4f), (30.4f, 3.1f), (30.5f, 2.8f),
                    (30.6f, 2.5f), (30.7f, 2.2f), (30.8f, 1.9f), (30.9f, 1.6f),
                    (31.0f, 1.3f), (31.1f, 1.0f), (31.2f, 0.7f), (31.3f, 0.4f), (31.4f, 0.1f)
                }
            }
        };
    }
}
