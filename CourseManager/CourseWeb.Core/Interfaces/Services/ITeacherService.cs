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
    public  interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(Guid teacherId);
        int Create(TeacherRequest request);
        int Update(Guid teacherId, TeacherRequest request);
        int Delete(Guid teacherId);
        int DeleteList(Guid teacherId);
        object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status);
        Stream ExportExcel();
    }
}
