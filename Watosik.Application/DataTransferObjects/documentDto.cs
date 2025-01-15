using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Application.DataTransferObjects
{
    public class documentDto
    {
        public required int document_id { get; set; }
        public string title { get; set; }
        public string document_group { get; set; }
        public string file { get; set; }
    }
}

