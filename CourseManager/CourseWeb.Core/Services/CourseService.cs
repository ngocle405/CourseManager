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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public object Create(CourseRequest request)
        {
            var isValid = ValidateObject(request);
            if (isValid == true)
            {
                return _courseRepository.Create(request);
            }
            return -1;
        }

        public int Delete(Guid CourseId)
        {
            return _courseRepository.Delete(CourseId);
        }

        public int DeleteList(Guid CourseId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            return _courseRepository.GetAll();
        }

        public object GetById(Guid CourseId)
        {
            return _courseRepository.GetById(CourseId);
        }

        public object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status,Guid? courseCategoryId,Guid? teacherId)
        {
            return _courseRepository.Paging(searchName,searchCode, pageSize, pageIndex, status,courseCategoryId,teacherId);
        }

        public int Update(Guid CourseId, CourseRequest request)
        {
            return _courseRepository.Update(CourseId,request);
        }
        bool ValidateObject(CourseRequest  entity)
        {
            var res = _courseRepository.FindByCode(entity.Code);
            if (res != null)
            {
                throw new ResponseException("Mã khóa học đã tồn tại trong hệ thống, vui lòng kiểm tra lại.");
            }
            return true;

        }
    }
}
