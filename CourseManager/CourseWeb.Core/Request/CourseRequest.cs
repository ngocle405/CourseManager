using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Request
{
    public class CourseRequest
    {
        public Guid CourseId { get; set; }
        public string Code { get; set; }
        public string CourseName { get; set; }
        public string EnglishName { get; set; }
        public string Title { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? CourseCategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int? CountLesson { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TeacherName { get; set; }
        public string CourseCategoryName { get; set; }
    }
}
