using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class NewCategory
    {
        public NewCategory()
        {
            News = new HashSet<New>();
        }

        public Guid NewCategoryId { get; set; }
        public string NewCategoryCode { get; set; }
        public string NewCategoryName { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<New> News { get; set; }
    }
}
