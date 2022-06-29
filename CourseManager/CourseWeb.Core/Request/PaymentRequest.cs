using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Request
{
    public class PaymentRequest
    {
        public Guid PaymentId { get; set; }
        public decimal? Money { get; set; }
        public Guid StudentId { get; set; }
        public Guid? CourseId { get; set; }
        public string ContentPayment { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? StatusPayment { get; set; }
    }
}
