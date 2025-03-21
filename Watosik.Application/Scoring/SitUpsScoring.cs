﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Watosik.Application.Scoring
{
    public static class SitUpsScoring
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

        // Scoring table for men based on age categories
        public static readonly Dictionary<string, List<(int Reps, float Points)>> Male = new()
        {
            // Age category: "do 20"
            { "do 20", new List<(int Reps, float Points)>
                {
                    (80, 16), (79, 15.8f), (78, 15.6f), (77, 15.4f), (76, 15.2f),
                    (75, 15), (74, 15), (73, 14.8f), (72, 14.6f), (71, 14.4f),
                    (70, 14.2f), (69, 14), (68, 13.8f), (67, 13.6f), (66, 13.4f),
                    (65, 13.2f), (64, 13), (63, 12.8f), (62, 12.6f), (61, 12.4f),
                    (60, 12), (59, 11.8f), (58, 11.6f), (57, 11.4f), (56, 11.2f),
                    (55, 11), (54, 10.8f), (53, 10.6f), (52, 10.4f), (51, 10.2f),
                    (50, 10), (49, 9.8f), (48, 9.6f), (47, 9.4f), (46, 9.2f),
                    (45, 9), (44, 8.8f), (43, 8.6f), (42, 8.4f), (41, 8.2f),
                    (40, 8), (39, 7.8f), (38, 7.6f), (37, 7.4f), (36, 7.2f),
                    (35, 7), (34, 6.8f), (33, 6.6f), (32, 6.4f), (31, 6.2f),
                    (30, 6)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(int Reps, float Points)>
                {
                    (80, 16), (79, 15.8f), (78, 15.6f), (77, 15.4f), (76, 15.2f),
                    (75, 15), (74, 14.8f), (73, 14.6f), (72, 14.4f), (71, 14.2f),
                    (70, 14), (69, 13.8f), (68, 13.6f), (67, 13.4f), (66, 13.2f),
                    (65, 13), (64, 12.8f), (63, 12.6f), (62, 12.4f), (61, 12.2f),
                    (60, 12), (59, 11.8f), (58, 11.6f), (57, 11.4f), (56, 11.2f),
                    (55, 11), (54, 10.8f), (53, 10.6f), (52, 10.4f), (51, 10.2f),
                    (50, 10), (49, 9.8f), (48, 9.6f), (47, 9.4f), (46, 9.2f),
                    (45, 9), (44, 8.8f), (43, 8.6f), (42, 8.4f), (41, 8.2f),
                    (40, 8), (39, 7.8f), (38, 7.6f), (37, 7.4f), (36, 7.2f),
                    (35, 7), (34, 6.8f), (33, 6.6f), (32, 6.4f), (31, 6.2f),
                    (30, 6)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(int Reps, float Points)>
                {
                    (80, 16), (79, 15.8f), (78, 15.6f), (77, 15.4f), (76, 15.2f),
                    (75, 15), (74, 14.8f), (73, 14.6f), (72, 14.4f), (71, 14.2f),
                    (70, 14), (69, 13.8f), (68, 13.6f), (67, 13.4f), (66, 13.2f),
                    (65, 13), (64, 12.8f), (63, 12.6f), (62, 12.4f), (61, 12.2f),
                    (60, 12), (59, 11.8f), (58, 11.6f), (57, 11.4f), (56, 11.2f),
                    (55, 11), (54, 10.8f), (53, 10.6f), (52, 10.4f), (51, 10.2f),
                    (50, 10), (49, 9.8f), (48, 9.6f), (47, 9.4f), (46, 9.2f),
                    (45, 9), (44, 8.8f), (43, 8.6f), (42, 8.4f), (41, 8.2f),
                    (40, 8), (39, 7.8f), (38, 7.6f), (37, 7.4f), (36, 7.2f),
                    (35, 7), (34, 6.8f), (33, 6.6f), (32, 6.4f), (31, 6.2f),
                    (30, 6)
                }
            }
        };
        // Scoring table for women based on age categories
        public static readonly Dictionary<string, List<(int Reps, float Points)>> Female = new()
        {
            // Age category: "do 20"
            { "do 20", new List<(int Reps, float Points)>
                {
                    (60, 16), (59, 15.8f), (58, 15.6f), (57, 15.4f),
                    (56, 15.2f), (55, 15), (54, 14.8f), (53, 14.6f),
                    (52, 14.4f), (51, 14.2f), (50, 14), (49, 13.8f),
                    (48, 13.6f), (47, 13.4f), (46, 13.2f), (45, 13),
                    (44, 12.8f), (43, 12.6f), (42, 12.4f), (41, 12.2f),
                    (40, 12), (39, 11.8f), (38, 11.6f), (37, 11.4f),
                    (36, 11.2f), (35, 11), (34, 10.8f), (33, 10.6f),
                    (32, 10.4f), (31, 10.2f), (30, 10), (29, 9.8f),
                    (28, 9.6f), (27, 9.4f), (26, 9.2f), (25, 9),
                    (24, 8.8f), (23, 8.6f), (22, 8.4f), (21, 8.2f),
                    (20, 8), (19, 7.8f), (18, 7.6f), (17, 7.4f),
                    (16, 7.2f), (15, 7), (14, 6.8f), (13, 6.6f),
                    (12, 6.4f), (11, 6.2f), (10, 6), (9, 5.8f),
                    (8, 5.6f), (7, 5.4f), (6, 5.2f), (5, 5)
                }
            },

            // Age category: "21-25"
            { "21-25", new List<(int Reps, float Points)>
                {
                    (60, 16), (59, 15.8f), (58, 15.6f), (57, 15.4f),
                    (56, 15.2f), (55, 15), (54, 14.8f), (53, 14.6f),
                    (52, 14.4f), (51, 14.2f), (50, 14), (49, 13.8f),
                    (48, 13.6f), (47, 13.4f), (46, 13.2f), (45, 13),
                    (44, 12.8f), (43, 12.6f), (42, 12.4f), (41, 12.2f),
                    (40, 12), (39, 11.8f), (38, 11.6f), (37, 11.4f),
                    (36, 11.2f), (35, 11), (34, 10.8f), (33, 10.6f),
                    (32, 10.4f), (31, 10.2f), (30, 10), (29, 9.8f),
                    (28, 9.6f), (27, 9.4f), (26, 9.2f), (25, 9),
                    (24, 8.8f), (23, 8.6f), (22, 8.4f), (21, 8.2f),
                    (20, 8), (19, 7.8f), (18, 7.6f), (17, 7.4f),
                    (16, 7.2f), (15, 7), (14, 6.8f), (13, 6.6f),
                    (12, 6.4f), (11, 6.2f), (10, 6), (9, 5.8f),
                    (8, 5.6f), (7, 5.4f), (6, 5.2f), (5, 5)
                }
            },

            // Age category: "26-30"
            { "26-30", new List<(int Reps, float Points)>
                {
                    (60, 16), (59, 15.8f), (58, 15.6f), (57, 15.4f),
                    (56, 15.2f), (55, 15), (54, 14.8f), (53, 14.6f),
                    (52, 14.4f), (51, 14.2f), (50, 14), (49, 13.8f),
                    (48, 13.6f), (47, 13.4f), (46, 13.2f), (45, 13),
                    (44, 12.8f), (43, 12.6f), (42, 12.4f), (41, 12.2f),
                    (40, 12), (39, 11.8f), (38, 11.6f), (37, 11.4f),
                    (36, 11.2f), (35, 11), (34, 10.8f), (33, 10.6f),
                    (32, 10.4f), (31, 10.2f), (30, 10), (29, 9.8f),
                    (28, 9.6f), (27, 9.4f), (26, 9.2f), (25, 9),
                    (24, 8.8f), (23, 8.6f), (22, 8.4f), (21, 8.2f),
                    (20, 8), (19, 7.8f), (18, 7.6f), (17, 7.4f),
                    (16, 7.2f), (15, 7), (14, 6.8f), (13, 6.6f),
                    (12, 6.4f), (11, 6.2f), (10, 6), (9, 5.8f),
                    (8, 5.6f), (7, 5.4f), (6, 5.2f), (5, 5)
                }
            }
        };
    }
}
