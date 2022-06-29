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
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        public CourseCategoryService( ICourseCategoryRepository courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }
        public int Create(CourseCategoryRequest request)
        {
            return _courseCategoryRepository.Create(request);
        }

        public int Delete(Guid CourseCategoryId)
        {
            return _courseCategoryRepository.Delete(CourseCategoryId);
        }

        public int DeleteList(Guid CourseCategoryId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseCategory> GetAll()
        {
            return _courseCategoryRepository.GetAll();
        }

        public CourseCategory GetById(Guid CourseCategoryId)
        {
            return _courseCategoryRepository.GetById(CourseCategoryId);
        }

        public object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status)
        {
            return _courseCategoryRepository.Paging(searchName,searchCode, pageSize, pageIndex, status);
        }

        public int Update(Guid CourseCategoryId, CourseCategoryRequest request)
        {
            return _courseCategoryRepository.Update(CourseCategoryId,request);
        }
    }
}
