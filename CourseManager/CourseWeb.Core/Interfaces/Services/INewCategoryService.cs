using CourseWeb.Core.Entities;
using CourseWeb.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Services
{
    public interface INewCategoryService
    {
        IEnumerable<NewCategory> GetAll();
        NewCategory GetById(Guid NewCategoryId);
        int Create(NewCategoryRequest obj);
        int Update(Guid NewCategoryId, NewCategoryRequest obj);
        int Delete(Guid NewCategoryId);
        int DeleteList(Guid NewCategoryId);
        object Paging(string searchName, string searchCode, int pageSize, int pageIndex,bool? status);
        Stream ExportExcel();
    }
}
