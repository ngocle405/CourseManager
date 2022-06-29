using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Models
{
    public class NewCategoryRequest
    {
        public Guid NewCategoryId { get; set; }
        public string NewCategoryCode { get; set; }
        public string NewCategoryName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
