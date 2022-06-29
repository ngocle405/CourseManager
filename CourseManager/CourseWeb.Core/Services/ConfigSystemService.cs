using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Services
{
    public class ConfigSystemService : IConfigSystemService
    {
        private IConfigSystemRepository _configSystemRepository;
        public ConfigSystemService(IConfigSystemRepository configSystemRepository)
        {
            _configSystemRepository = configSystemRepository;
        }
        public int Create(ConfigSystemRequest request)
        {
            return _configSystemRepository.Create(request);
        }

        public int Delete(Guid configId)
        {
            return _configSystemRepository.Delete(configId);
        }

        public int DeleteList(Guid configId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConfigSystem> GetAll()
        {
            return _configSystemRepository.GetAll();
        }

        public ConfigSystem GetById(Guid configId)
        {
            return _configSystemRepository.GetById(configId);
        }

        public object Paging(string searchAddress, int pageSize, int pageIndex, bool? status)
        {
            return _configSystemRepository.Paging(searchAddress, pageSize, pageIndex, status);
        }

        public int Update(Guid configId, ConfigSystemRequest request)
        {
            return _configSystemRepository.Update(configId, request);
        }
    }
}
