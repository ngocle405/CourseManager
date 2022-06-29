using CourseWeb.Core;
using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Infastructure.Repositories
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly CourseManagerContext _courseManagerContext;
        public CourseCategoryRepository(CourseManagerContext courseManagerContext)
        {
            _courseManagerContext = courseManagerContext;
        }

        public int Create(CourseCategoryRequest request)
        {
            CourseCategory courseCategory = new CourseCategory()
            {
                CourseCategoryId = Guid.NewGuid(),
                CourseCategoryCode = request.CourseCategoryCode,
                CourseCategoryName = request.CourseCategoryName,
                Description = request.Description,
                Status = request.Status,
                CreateBy = "admin",
                Createdate = DateTime.Now,
            };
            _courseManagerContext.CourseCategories.Add(courseCategory);
            var res = _courseManagerContext.SaveChanges();
            return res;
            
        }

        public int Delete(Guid CourseCategoryId)
        {
            var coursecategory = _courseManagerContext.CourseCategories.Find(CourseCategoryId);
            if (coursecategory==null) 
            {
                return -1;
            }
            _courseManagerContext.CourseCategories.Remove(coursecategory);
            var res = _courseManagerContext.SaveChanges();
            return res;
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
            var res = _courseManagerContext.CourseCategories;
            return res;
        }

        public CourseCategory GetById(Guid CourseCategoryId)
        {
            var res = _courseManagerContext.CourseCategories.Find(CourseCategoryId);
            if (res == null) return null;
            return res;

        }

        public object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.CourseCategories select t1;
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.CourseCategoryName.Contains(searchName));
            if (!string.IsNullOrEmpty(searchCode))
                result = result.Where(x => x.CourseCategoryCode.Contains(searchCode));
            if (status != null)
                result = result.Where(x => x.Status == status);
            int total = result.Count();
            int totalPage = (int)Math.Ceiling(total / (double)pageSize);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            PagingModel model = new PagingModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPage,
                TotalRecords = total,
                HasNextPage = pageIndex < totalPage,
                HasPreviousPage = pageIndex > 1,
                Data = result.ToList()
            };
            return model;
        }

        public int Update(Guid CourseCategoryId, CourseCategoryRequest request)
        {
            CourseCategory courseCategory = _courseManagerContext.CourseCategories.Find(CourseCategoryId);
            if (courseCategory == null) return -1;
            courseCategory. CourseCategoryCode = request.CourseCategoryCode;
            courseCategory.CourseCategoryName = request.CourseCategoryName;
            courseCategory.Description = request.Description;
            courseCategory.Status = request.Status;
            courseCategory.UpdateBy = "admin";
            courseCategory.UpdateDate = DateTime.Now;
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
    }
}
