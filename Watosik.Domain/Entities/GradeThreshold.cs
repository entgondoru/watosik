﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Entities
{
    public class GradeThreshold
    {
        public string Grade { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}
