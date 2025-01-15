using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Entities
{
    public class CompetitionResult
    {
        public string CompetitionName { get; set; }
        public float Result { get; set; }
        public int Points { get; set; }
    }
}
