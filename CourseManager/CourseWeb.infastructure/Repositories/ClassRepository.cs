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
    public class ClassRepository : IClassRepository
    {
        private CourseManagerContext _courseManagerContext;
        public ClassRepository(CourseManagerContext courseManagerContext)
        {
            _courseManagerContext = courseManagerContext;
        }
        public int Create(ClassRequest request)
        {
            var con = new Class()
            {
                ClassId = Guid.NewGuid(),
                ClassCode=request.ClassCode,
                ClassName=request.ClassName,
                EndDate=request.EndDate,
                StartDate=request.StartDate,
                TeacherId=request.TeacherId,
                Status=request.Status
            };
          
            _courseManagerContext.Classes.Add(con);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid classId)
        {
            var config = _courseManagerContext.Classes.Find(classId);
            if (config == null)
            {
                return -1;
            }
            _courseManagerContext.Classes.Remove(config);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int DeleteList(Guid classId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public object FindByCode(string code)
        {
            return _courseManagerContext.Classes.FirstOrDefault(x => x.ClassCode == code);
        }

        public IEnumerable<Class> GetAll()
        {
            return _courseManagerContext.Classes;
        }

        public Class GetById(Guid configId)
        {
            var res = _courseManagerContext.Classes.Find(configId);
            if (res == null) return null;
            return res;
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.Classes select new Class() {
                ClassName = t1.ClassName,
                ClassCode=t1.ClassCode,
                EndDate=t1.EndDate,
                Status=t1.Status,
                TeacherId=t1.TeacherId,
                TeacherName=t1.Teacher.TeacherName,
                ClassId=t1.ClassId,
                StartDate=t1.StartDate,
            };
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.ClassName.Contains(searchName));
            if (status != null)
                result = result.Where(x => x.Status == status);
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

        public int Update(Guid classId, ClassRequest request)
        {
            var con = _courseManagerContext.Classes.Find(classId);
            con.ClassCode = request.ClassCode;
            con.ClassName = request.ClassName;
            con.EndDate = request.EndDate;
            con.StartDate = request.StartDate;
            con.TeacherId = request.TeacherId;
            con.Status = request.Status;
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
    }
}
