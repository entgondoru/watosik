using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Application.DataTransferObjects
{
    public class phone_book_contactDto
    {
        public required int contact_id { get; set; }
        public string contact_first_name { get; set; }
        public string contact_last_name { get; set; }
        public string phone_number { get; set; }
        public string office { get; set; }
        public string contact_category { get; set; }
        public int user_id { get; set; }
    }
}

