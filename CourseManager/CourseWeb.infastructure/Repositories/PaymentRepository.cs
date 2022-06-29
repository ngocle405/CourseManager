using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.infastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private CourseManagerContext _courseManagerContext;
        public PaymentRepository(CourseManagerContext courseManagerContext)
        {
            _courseManagerContext = courseManagerContext;
        }
        public int Create(PaymentRequest request)
        {
            var entities = new PaymentOfCouse()
            {
                PaymentId = Guid.NewGuid(),
                Money = request.Money,
                StatusPayment = request.StatusPayment,
                ContentPayment = request.ContentPayment,
                StudentId = request.StudentId,
                CreateDate = DateTime.Now,
            };
            _courseManagerContext.PaymentOfCouses.Add(entities);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid paymentId)
        {
            var payment = _courseManagerContext.PaymentOfCouses.Find(paymentId);
            if (payment == null) return -1;
            _courseManagerContext.PaymentOfCouses.Remove(payment);
            var res = _courseManagerContext.SaveChanges();
            return res;
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
            var res = _courseManagerContext.PaymentOfCouses.Where(x => x.PaymentId == paymentId).FirstOrDefault();
            if (res == null) return null;
            return res;
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status,Guid? courseId)
        {
            var result = from t1 in _courseManagerContext.PaymentOfCouses
                         join t2 in _courseManagerContext.Students on t1.StudentId equals t2.StudentId
                         join t3 in _courseManagerContext.Courses on t2.CourseId equals t3.CourseId
                         select new
                         {
                             t3.CourseId,
                             t1.Money,
                             t1.PaymentId,
                             t1.CreateDate,
                             t1.StatusPayment,
                             t1.ContentPayment,
                             t1.CreateBy,
                             t1.StudentId,
                             t2.StudentName,
                             t3.CourseName,
                             t3.Price
                         };
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.StudentName.Contains(searchName));
        
            if (status != null)
            {
                result = result.Where(x => x.StatusPayment == status);
            }

            if (courseId != null)
            {
                result = result.Where(x => x.CourseId == courseId);
            }
          
            int total = result.Count();
            int totalPage = (int)Math.Ceiling(total / (double)pageSize);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            PagingModel model = new PagingModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPage,
                TotalRecords = total,
                HasNextPage = pageIndex < totalPage,
                HasPreviousPage = pageIndex > 1,
                Data = result.ToList()
            };
            return model;
        }

        public int Update(Guid paymentId, PaymentRequest request)
        {
            var entities = _courseManagerContext.PaymentOfCouses.Find(paymentId);
            entities. Money = request.Money;
            entities.StatusPayment = request.StatusPayment;
            entities.ContentPayment = request.ContentPayment;
            entities.StudentId = request.StudentId;
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
    }
}
