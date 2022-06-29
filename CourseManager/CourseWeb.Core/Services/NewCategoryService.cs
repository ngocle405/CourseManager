using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Services
{
    public class NewCategoryService : INewCategoryService
    {
        private INewCategoryRepository _newCategoryRepository;
        public NewCategoryService(INewCategoryRepository newCategoryRepository)
        {
            _newCategoryRepository = newCategoryRepository;
        }

        public int Create(NewCategoryRequest request)
        {
            return _newCategoryRepository.Create(request);
        }

        public int Delete(Guid NewCategoryId)
        {
            return _newCategoryRepository.Delete(NewCategoryId);
        }

        public int DeleteList(Guid NewCategoryId)
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
           return _newCategoryRepository.ExportExcel();
        }

        public IEnumerable<NewCategory> GetAll()
        {
            return _newCategoryRepository.GetAll();
        }

        public NewCategory GetById(Guid NewCategoryId)
        {
            return _newCategoryRepository.GetById(NewCategoryId);
        }

        public object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status)
        {
            return _newCategoryRepository.Paging(searchName,searchCode,pageSize,pageIndex,status);
        }

        public int Update(Guid NewCategoryId, NewCategoryRequest request)
        {
            return _newCategoryRepository.Update(NewCategoryId,request);
        }
    }
}
