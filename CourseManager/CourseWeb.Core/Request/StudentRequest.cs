using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Request
{
    public  class StudentRequest
    {
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public Guid CourseId { get; set; }
        public Guid? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Level { get; set; }
        public string Know { get; set; }
        public string WorkLocation { get; set; }

    }
}
