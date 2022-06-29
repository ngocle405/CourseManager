using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class Student
    {
        public Student()
        {
            PaymentOfCouses = new HashSet<PaymentOfCouse>();
        }

        public Guid StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Status { get; set; }
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Level { get; set; }
        public string Know { get; set; }
        public string WorkLocation { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<PaymentOfCouse> PaymentOfCouses { get; set; }
    }
}
