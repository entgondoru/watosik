using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain
{
    public class document
    {
        [Key]
        public required int document_id { get; set; }
        public string title { get; set; }
        public string document_group { get; set; }
        public string file { get; set; }
    }
}
