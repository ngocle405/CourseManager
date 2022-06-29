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

    public class TeacherRepository : ITeacherRepository
    {
        private CourseManagerContext _courseManagerContext;
        private IStorageRepository _storageRepository;
        public TeacherRepository(CourseManagerContext courseManagerContext, IStorageRepository storageRepository)
        {
            _courseManagerContext = courseManagerContext;
            _storageRepository = storageRepository;
        }
        public int Create(TeacherRequest request)
        {
            Teacher teacher = new Teacher()
            {
                TeacherId = Guid.NewGuid(),
                TeacherCode = request.TeacherCode,
                TeacherName = request.TeacherName,
                Address = request.Address,
                Email
                = request.Email,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Phone = request.Phone,
                Status = request.Status,
                Description = request.Description,
                Regular=request.Regular,
                Say=request.Say,
                CreateBy = "admin",
                CreateDate = DateTime.Now,
            };
            if (request.Image != null)
            {
                var arrData = request.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    teacher.Image = $"{savePath}";
                    _storageRepository.SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _courseManagerContext.Add(teacher);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid teacherId)
        {
            Teacher teacher = _courseManagerContext.Teachers.Find(teacherId);
            if (teacher == null) return -1;
            _courseManagerContext.Teachers.Remove(teacher);
            var res = _courseManagerContext.SaveChanges();
            return res;

        }

        public int DeleteList(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
            throw new NotImplementedException();
        }

        public object FindByCode(string code)
        {
            return _courseManagerContext.Teachers.FirstOrDefault(x => x.TeacherCode == code);
        }

        public IEnumerable<Teacher> GetAll()
        {
            var res = _courseManagerContext.Teachers.ToList();
            return res;
        }

        public Teacher GetById(Guid teacherId)
        {
            var res = _courseManagerContext.Teachers.Find(teacherId);
            if (res == null) return null;
            return res;
        }

        public object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.Teachers
                         select new
                         {
                             t1.TeacherId,
                             t1.TeacherCode,
                             t1.TeacherName,
                             t1.Status,
                             t1.Phone,
                             t1.CreateDate,
                             t1.Image,
                             t1.Email,
                             t1.CreateBy,
                             t1.UpdateDate,
                             t1.UpdateBy,
                             t1.Gender,
                             t1.Description,
                             t1.DateOfBirth,
                             t1.Address,
                             t1.Regular

                         };
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.TeacherName.Contains(searchName));
            if (!string.IsNullOrEmpty(searchCode))
                result = result.Where(x => x.TeacherCode.Contains(searchCode));
            if (status != null)
            {
                result = result.Where(x => x.Status == status);
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

        public int Update(Guid teacherId, TeacherRequest request)
        {
            Teacher teacher = _courseManagerContext.Teachers.Find(teacherId);
            if (teacher == null) return -1;
            teacher.TeacherCode = request.TeacherCode;
            teacher.TeacherName = request.TeacherName;
            teacher.Address = request.Address;
            teacher.Email = request.Email;
            teacher.DateOfBirth = request.DateOfBirth;
            teacher.Gender = request.Gender;
            teacher.Phone = request.Phone;
            teacher.Status = request.Status;
            teacher.Description = request.Description;
            teacher.Regular = request.Regular;
            teacher.Say = request.Say;
            teacher.UpdateDate = DateTime.Now;

            if (request.Image != null)
            {
                var arrData = request.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    teacher.Image = $"{savePath}";
                    _storageRepository.SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            var res = _courseManagerContext.SaveChanges();
            return res;

        }
    }
}
