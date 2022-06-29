using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Repositories
{
    public   interface IClassRepository
    {
        public object FindByCode(string code);
        IEnumerable<Class> GetAll();
        Class GetById(Guid configId);
        int Create(ClassRequest request);
        int Update(Guid classId, ClassRequest request);
        int Delete(Guid classId);
        int DeleteList(Guid classId);
        int ExportExcel();
        object Paging(string searchName, int pageSize, int pageIndex, bool? status);
    }
}
