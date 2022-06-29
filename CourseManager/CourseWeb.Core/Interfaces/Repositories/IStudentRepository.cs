using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Repositories
{
  public  interface IStudentRepository
    {
       object GetAll();
        Student GetById(Guid studentId);
        int Create(StudentRequest request);
        int Update(Guid studentId, StudentRequest request);
        int ChangeStatus(Guid studentId, StudentRequest request);
        public object ListRegister(string searchName, int pageSize, int pageIndex, bool? status);
        int Delete(Guid studentId);
        int DeleteList();
        object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status,Guid? courseId, Guid? classId);
        Stream ExportExcel();
        object FindByCode(string code);
    }
}
