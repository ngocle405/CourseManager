using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Services
{
    public interface IStudentService
    {
       object GetAll();
        Student GetById(Guid studentId);
        int? Create(StudentRequest request);
        int Update(Guid studentId, StudentRequest request);
        int Delete(Guid studentId);
        public object ListRegister(string searchName, int pageSize, int pageIndex, bool? status);
        int ChangeStatus(Guid studentId, StudentRequest request);
        int DeleteList();
        object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status, Guid? courseId,Guid? classId);
        Stream ExportExcel();
    }
}
