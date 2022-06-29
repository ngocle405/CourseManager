using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class PaymentOfCouse
    {
        public Guid PaymentId { get; set; }
        public decimal? Money { get; set; }
        public Guid StudentId { get; set; }
        public Guid? CourseId { get; set; }
        public string ContentPayment { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? StatusPayment { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Students { get; set; }
    }
}
