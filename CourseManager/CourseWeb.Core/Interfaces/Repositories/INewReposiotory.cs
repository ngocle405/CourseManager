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
    public interface INewReposiotory
    {
        IEnumerable<New> GetAll();
        New GetById(Guid NewCategoryId);
        int Create(NewRequest request);
        int Update(Guid NewId, NewRequest request);
        int Delete(Guid NewId);
        int DeleteList(Guid NewId);
        object Paging(string searchName, int pageSize, int pageIndex, bool? status,Guid? newCategoryId);
        Stream ExportExcel();
      
    }
}
