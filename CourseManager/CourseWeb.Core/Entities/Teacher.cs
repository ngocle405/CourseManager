using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Courses = new HashSet<Course>();
        }

        public Guid TeacherId { get; set; }
        public string TeacherCode { get; set; }
        public string Image { get; set; }
        public string TeacherName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int? Gender { get; set; }
        public string Say { get; set; }
        public string Regular { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Status { get; set; }
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
