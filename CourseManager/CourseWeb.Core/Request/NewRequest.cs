using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Request
{
   public class NewRequest
    {
        public Guid NewId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public Guid? NewCategoryId { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public int Type { get; set; }
        
    }
}
