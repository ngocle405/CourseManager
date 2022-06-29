using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            Courses = new HashSet<Course>();
        }

        public Guid CourseCategoryId { get; set; }
        public string CourseCategoryCode { get; set; }
        public string CourseCategoryName { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
