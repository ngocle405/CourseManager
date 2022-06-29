using CourseWeb.Core.Entities;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Services
{
    public  interface ICourseCategoryService
    {
        IEnumerable<CourseCategory> GetAll();
        CourseCategory GetById(Guid CourseCategoryId);
        int Create(CourseCategoryRequest request);
        int Update(Guid CourseCategoryId, CourseCategoryRequest request);
        int Delete(Guid CourseCategoryId);
        int DeleteList(Guid CourseCategoryId);
        int ExportExcel();
        object Paging(string searchName, string searchCode , int pageSize, int pageIndex, bool? status);
    }
}
