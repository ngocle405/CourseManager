using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class Course
    {
        public Course()
        {
            PaymentOfCouses = new HashSet<PaymentOfCouse>();
         
        }

        public Guid CourseId { get; set; }
        public string Code { get; set; }
        public Guid? TeacherId { get; set; }
        public string EnglishName { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid? CourseCategoryId { get; set; }
        public string Note { get; set; }
        public int? CountLesson { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Status { get; set; }
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }
        public virtual Teacher Teachers { get; set; }
        public virtual ICollection<PaymentOfCouse> PaymentOfCouses { get; set; }
      
    }
}
