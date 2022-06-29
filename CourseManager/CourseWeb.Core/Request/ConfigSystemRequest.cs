using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Request
{
    public class ConfigSystemRequest
    {
        public Guid SystemId { get; set; }
        public string Image { get; set; }
       
        public string Address { get; set; }
        public string IdNo { get; set; }
        public string Phone { get; set; }
        public string Hotline1 { get; set; }
        public string Hotline2 { get; set; }
        public string Description { get; set; }
        public string TitleDefault { get; set; }
        public string Information { get; set; }
        public bool Status { get; set; }
    }
}
