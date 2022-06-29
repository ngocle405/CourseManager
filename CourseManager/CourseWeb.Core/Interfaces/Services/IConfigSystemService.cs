using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Services
{
    public interface IConfigSystemService
    {
        IEnumerable<ConfigSystem> GetAll();
        ConfigSystem GetById(Guid configId);
        int Create(ConfigSystemRequest request);
        int Update(Guid configId, ConfigSystemRequest request);
        int Delete(Guid configId);
        int DeleteList(Guid configId);
        int ExportExcel();
        object Paging(string searchAddress, int pageSize, int pageIndex, bool? status);
    }
}
