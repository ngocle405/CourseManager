using CourseWeb.Core.Entities;
using CourseWeb.Core.Exceptions;
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
    public class ClassService : IClassService
    {
        private IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public int Create(ClassRequest request)
        {
            var valid = ValidateObject(request);
            if (valid == true)
            {
                return _classRepository.Create(request);
            }
            return -1;
            
        }

        public int Delete(Guid classId)
        {
            return _classRepository.Delete(classId);
        }

        public int DeleteList(Guid classId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetAll()
        {
            return _classRepository.GetAll();
        }

        public Class GetById(Guid configId)
        {
            return _classRepository.GetById(configId);
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status)
        {

            return _classRepository.Paging(searchName, pageSize, pageIndex, status);
        }

        public int Update(Guid classId, ClassRequest request)
        {
            return _classRepository.Update(classId, request);
        }
        bool ValidateObject(ClassRequest entity)
        {
            var res = _classRepository.FindByCode(entity.ClassCode);
            if (res != null)
            {
                throw new ResponseException("Mã lớp đã tồn tại trong hệ thống, vui lòng kiểm tra lại.");
            }
            return true;

        }
    }
}
