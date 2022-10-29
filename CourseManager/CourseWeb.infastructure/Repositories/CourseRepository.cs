
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
    public class CourseRepository : ICourseRepository
    {
        private IStorageRepository _storageRepository;
        private readonly CourseManagerContext _courseManagerContext;
        public CourseRepository(CourseManagerContext courseManagerContext, IStorageRepository storageRepository)
        {
            _courseManagerContext = courseManagerContext;
            _storageRepository = storageRepository;
        }
        public int Create(CourseRequest request)
        {
            Course course = new Course()
            {
                CourseId=Guid.NewGuid(),
                Code=request.Code,
                EnglishName=request.EnglishName,
                CourseName = request.CourseName,
                TeacherId = request.TeacherId,
                CourseCategoryId = request.CourseCategoryId,
                Image = request.Image,
                Title = request.Title,
                Description = request.Description,
                Note = request.Note,
                CountLesson = request.CountLesson,
                Price = request.Price,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status,
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                
            };
          
            _courseManagerContext.Courses.Add(course);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid CourseId)
        {
            var course = _courseManagerContext.Courses.Find(CourseId);
            if (course == null) return -1;
            _courseManagerContext.Courses.Remove(course);
            var res = _courseManagerContext.SaveChanges();
            return res;

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
            var result = from t1 in _courseManagerContext.Courses
                         join t2 in _courseManagerContext.CourseCategories on t1.CourseCategoryId equals t2.CourseCategoryId
                         join t3 in _courseManagerContext .Teachers on t1.TeacherId equals t3.TeacherId
                         select new
                         {
                             t1.Code,
                             t1.CourseId,
                             t1.CourseName,
                             t1.CourseCategoryId,
                             t1.CountLesson,
                             t1.Description,
                             t1.Note,
                             t1.EndDate,
                             t1.StartDate,
                             t1.Image,
                             t1.Price,
                             t1.Status,
                             t1.CreateDate,
                             t1.TeacherId,
                             t2.CourseCategoryName,
                             t3.TeacherName
                         };
            return result;
        }

        public  object GetById(Guid CourseId)
        {
            var res = _courseManagerContext.Courses.Where(x => x.CourseId == CourseId).Select(p => new CourseRequest()
            {
                Code=p.Code,
                CourseName=p.CourseName,
                CountLesson=p.CountLesson,
                Description=p.Description,
                EndDate=p.EndDate,
                StartDate=p.StartDate,
                EnglishName=p.EnglishName,
                Image=p.Image,
                Note=p.Note,
                Price=p.Price,
                Title=p.Title,
                TeacherId=p.TeacherId,
                Status=p.Status,
                CreateDate=p.CreateDate,
                CourseId=p.CourseId,
                CourseCategoryName=p.CourseCategory.CourseCategoryName,
                TeacherName=p.Teachers.TeacherName,
                CourseCategoryId=p.CourseCategoryId,
            }).FirstOrDefault();
            if (res == null) return null;
      
            return res;
        }

        public object Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status,Guid? courseCategoryId,Guid? teacherId)
        {
            var result = from t1 in _courseManagerContext.Courses select new
            {
                t1.Code,
                t1.CourseCategory.CourseCategoryName,
                t1.CourseId,
                t1.CourseName,
                t1.CourseCategoryId,
                t1.CountLesson,
                t1.Description,t1.Note,
                t1.EndDate,
                t1.StartDate,
                t1.Image,
                t1.Price,
                t1.Status,
                t1.Teachers.TeacherName,
                t1.CreateDate,
                t1.TeacherId
            };
            if (!string.IsNullOrEmpty(searchCode))
                result = result.Where(x => x.Code.Contains(searchCode));
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.CourseName.Contains(searchName));
            if (status != null)
            {
                result = result.Where(x => x.Status == status);
            }
            if (courseCategoryId != null)
            {
                result = result.Where(x => x.CourseCategoryId == courseCategoryId);
            }
            if(teacherId != null)
            {
                result = result.Where(x => x.TeacherId == teacherId);
            }
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

        public int Update(Guid CourseId, CourseRequest request)
        {
            Course course = _courseManagerContext.Courses.Find(CourseId);
            if (course == null) return -1;
            course.Code = request.Code;
            course.CourseName = request.CourseName;
            course.TeacherId = request.TeacherId;
            course.Title = request.Title;
            course.EnglishName = request.EnglishName;
            course.CourseCategoryId = request.CourseCategoryId;
            course.Description = request.Description;
            course.Note = request.Note;
            course.CountLesson = request.CountLesson;
            course.Price = request.Price;
            course.StartDate = request.StartDate;
            course.EndDate = request.EndDate;
            course.Status = request.Status;
            course.UpdateDate = DateTime.Now;
            course.UpdateBy = "admin";
            course.Image = request.Image;
           
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public object FindByCode(string code)
        {
            var res = _courseManagerContext.Courses.Where(x => x.Code == code).FirstOrDefault();
            if (res == null) return null;
            return res;
        }
    }
}
