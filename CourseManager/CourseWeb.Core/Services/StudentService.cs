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
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public int ChangeStatus(Guid studentId, StudentRequest request)
        {
            return _studentRepository.ChangeStatus(studentId, request);
        }

        public int? Create(StudentRequest request)
        {
            var isValid = ValidateObject(request);
            //validate đặc thù cho từng đối tượng.-> cho các service con tự xử lí
           
            if (isValid == true)//đã hợp lệ
            {
                var entities = _studentRepository.Create(request);
                return entities;
            }
            return null;
            
        }

        public int Delete(Guid studentId)
        {
           return  _studentRepository.Delete(studentId);
        }

        public int DeleteList()
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(Guid studentId)
        {
            return _studentRepository.GetById(studentId);
        }

        public object ListRegister(string searchName, int pageSize, int pageIndex, bool? status)
        {
            return _studentRepository.ListRegister(searchName, pageSize, pageIndex, status);
        }

        public object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status, Guid? courseId, Guid? classId)
        {
            return _studentRepository.Paging(searchName, searchCode, pageSize, pageIndex, status, courseId,classId);
        }

        public int Update(Guid studentId, StudentRequest request)
        {
            return _studentRepository.Update(studentId, request);
        }
        bool ValidateObject(StudentRequest entity)
        {
            var res = _studentRepository.FindByCode(entity.StudentCode);
            if (res != null)
            {
                throw new ResponseException("Mã học viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại.");
            }
            return true;

        }

    }
}
