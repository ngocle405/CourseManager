using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Services
{
    public class PaymentService : IPaymentService
    {
        public IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public int Create(PaymentRequest request)
        {
            return _paymentRepository.Create(request);
        }

        public int Delete(Guid paymentId)
        {
           return  _paymentRepository.Delete(paymentId);
        }

        public int DeleteList(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentOfCouse> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentOfCouse GetById(Guid paymentId)
        {
            return _paymentRepository.GetById(paymentId);
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status, Guid? courseId)
        {
            return _paymentRepository.Paging(searchName, pageSize, pageIndex, status, courseId);
        }

        public int Update(Guid paymentId, PaymentRequest request)
        {
            return _paymentRepository.Update(paymentId, request);
        }
    }
}
