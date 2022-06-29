using CourseWeb.Core.Entities;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Repositories
{
    public interface INewCategoryRepository
    {
        IEnumerable<NewCategory> GetAll();
        NewCategory GetById(Guid NewCategoryId);
        int Create(NewCategoryRequest request);
        int Update(Guid NewCategoryId, NewCategoryRequest request);
        int Delete(Guid NewCategoryId);
        int DeleteList(Guid NewCategoryId);
        object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status);
        Stream ExportExcel();
    }
}
