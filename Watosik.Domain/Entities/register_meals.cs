using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Watosik.Domain
{
    public class register_meals
    {
        [Key]
        public required int id { get; set; }
        public DateTime date { get; set; }
        public string sw1_breakfast { get; set; }
        public string sw1_dinner { get; set; }
        public string sw1_supper { get; set;}
        public string sw2_breakfast { get;set;}
        public string sw2_dinner { get; set; }
        public string sw2_supper { get; set;}
        public string sw3_breakfast { get;set;}
        public string sw3_dinner { get; set; }  
        public string sw3_supper { get; set;}
        public string csk_breakfast { get; set; }
        public string csk_dinner { get; set; }
        public string csk_supper { get; set; }
    }
}
