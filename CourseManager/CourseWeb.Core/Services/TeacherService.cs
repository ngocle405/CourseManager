using CourseWeb.Core.Entities;
using CourseWeb.Core.Exceptions;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public int Create(TeacherRequest request)
        {
            var isValid = ValidateObject(request);
            if (isValid == true)
            {
                return _teacherRepository.Create(request);
            }
            return -1;
          
        }

        public int Delete(Guid teacherId)
        {
            return _teacherRepository.Delete(teacherId);
        }

        public int DeleteList(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetById(Guid teacherId)
        {
            return _teacherRepository.GetById(teacherId);
        }

        public object Paging(string searchName, string searchCode,int pageSize, int pageIndex, bool? status)
        {
            return _teacherRepository.Paging(searchName, searchCode, pageSize, pageIndex, status);
        }

        public int Update(Guid teacherId, TeacherRequest request)
        {
            return _teacherRepository.Update(teacherId,request);
        }
        bool ValidateObject(TeacherRequest entity)
        {
            var res = _teacherRepository.FindByCode(entity.TeacherCode);
            if (res != null)
            {
                throw new ResponseException("Mã giáo viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại.");
            }
            return true;

        }
    }
}
