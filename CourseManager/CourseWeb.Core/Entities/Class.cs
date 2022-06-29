using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public bool? Status { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
