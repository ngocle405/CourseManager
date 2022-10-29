using CourseWeb.Core;
using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.infastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private CourseManagerContext _courseManagerContext;
        private IStorageRepository _storageRepository;
        public StudentRepository(CourseManagerContext courseManagerContext, IStorageRepository storageRepository)
        {
            _courseManagerContext = courseManagerContext;
            _storageRepository = storageRepository;
        }

        public int ChangeStatus(Guid studentId, StudentRequest request)
        {
            var obj = _courseManagerContext.Students.Find(studentId);
            if (obj == null) return -1;
            obj.Status = request.Status;
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Create(StudentRequest request)
        {
            var obj = new Student()
            {
                StudentId = Guid.NewGuid(),
                StudentCode = request.StudentCode,
                StudentName = request.StudentName,
                Address = request.Address,
                CourseId = request.CourseId,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                Status = request.Status,
                CreateDate = DateTime.Now,
                Description = request.Description,
                Know = request.Know,
                Level = request.Level,
                ClassId = request.ClassId,
                WorkLocation = request.WorkLocation,
                CreateBy = "admin",
                Image=request.Image
            };
            
            //if (request.Image != null)
            //{
            //    var arrData = request.Image.Split(';');
            //    if (arrData.Length == 3)
            //    {
            //        var savePath = $"{arrData[0]}";
            //        obj.Image = $"{savePath}";
            //        _storageRepository.SaveFileFromBase64String(savePath, arrData[2]);
            //    }
            //}
            _courseManagerContext.Students.Add(obj);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid studentId)
        {
            var student = _courseManagerContext.Students.Find(studentId);
            if (student == null) return -1;
            _courseManagerContext.Students.Remove(student);
            var res = _courseManagerContext.SaveChanges();
            return res;
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
            var res = from t1 in _courseManagerContext.Students
                      join t2 in _courseManagerContext.Courses on t1.CourseId equals t2.CourseId
                      select new
                      {
                          t1.StudentId,
                          t1.StudentCode,
                          t1.StudentName,
                          t1.Address,
                          t1.CourseId,
                          t1.Email,
                          t1.Description,
                          t2.Price,
                          t2.CourseName
                      };
            return res;
        }

        public Student GetById(Guid studentId)
        {
            var res = _courseManagerContext.Students.Find(studentId);
            if (res == null) return null;
            return res;
        }

        public object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status, Guid? courseId, Guid? classId)
        {
            var result = from t1 in _courseManagerContext.Students.Where(x => x.Status == true)
                         select new Student()
                         {
                             StudentId = t1.StudentId,
                             StudentName = t1.StudentName,
                             StudentCode = t1.StudentCode,
                             Status = t1.Status,
                             CourseId = t1.CourseId,
                             Address = t1.Address,
                             DateOfBirth = t1.DateOfBirth,
                             Email = t1.Email,
                             Phone = t1.Phone,
                             Image = t1.Image,
                             Gender = t1.Gender,
                             CreateDate = t1.CreateDate,
                             ClassId = t1.ClassId,
                             ClassName = t1.Class.ClassName
                         };
            if (!string.IsNullOrEmpty(searchCode))
                result = result.Where(x => x.StudentCode.Contains(searchCode));
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.StudentName.Contains(searchName));
            if (status != null)
                result = result.Where(x => x.Status == status);
            if (courseId != null)
                result = result.Where(x => x.CourseId == courseId);
            if (classId != null)
                result = result.Where(x => x.ClassId == classId);
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
        public object ListRegister(string searchName, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.Students.Where(x => x.Status == null)
                         select new
                         {
                             t1.StudentId,
                             t1.StudentName,
                             t1.Status,
                             t1.CourseId,
                             t1.Email,
                             t1.Phone,
                             t1.CreateDate,
                             t1.WorkLocation,
                             t1.Know,
                             t1.Level,
                         };

            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.StudentName.Contains(searchName));
            if (status != null)
                result = result.Where(x => x.Status == status);
            //if (courseId != null)
            //    result = result.Where(x => x.CourseId == courseId);
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

        public int Update(Guid studentId, StudentRequest request)
        {
            var obj = _courseManagerContext.Students.Find(studentId);
            if (obj == null) return -1;
            obj.StudentCode = request.StudentCode;
            obj.StudentName = request.StudentName;
            obj.Address = request.Address;
            obj.CourseId = request.CourseId;
            obj.DateOfBirth = request.DateOfBirth;
            obj.Email = request.Email;
            obj.Phone = request.Phone;
            obj.Gender = request.Gender;
            obj.ClassId = request.ClassId;
            obj.Status = request.Status;
            obj.UpdateDate = DateTime.Now;
            obj.Description = request.Description;
            obj.Image = request.Image;
            
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public object FindByCode(string code)
        {
            return _courseManagerContext.Students.FirstOrDefault(x => x.StudentCode == code);
        }
    }
}
