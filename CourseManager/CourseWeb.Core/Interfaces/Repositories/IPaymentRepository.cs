using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentOfCouse> GetAll();
        PaymentOfCouse GetById(Guid paymentId);
        int Create(PaymentRequest request);
        int Update(Guid paymentId, PaymentRequest request);
        int Delete(Guid paymentId);
        int DeleteList(Guid paymentId);
        int ExportExcel();
        object Paging(string searchName, int pageSize, int pageIndex, bool? status,Guid? courseId);
    }
}
