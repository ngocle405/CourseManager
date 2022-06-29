using CourseWeb.Core.Entities;
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
    public class NewService : INewService
    {
        private readonly INewReposiotory _newReposiotory;
        public NewService(INewReposiotory newReposiotory)
        {
            _newReposiotory = newReposiotory;
        }
        public int Create(NewRequest request)
        {
            return _newReposiotory.Create(request);
        }

        public int Delete(Guid NewId)
        {
            return _newReposiotory.Delete(NewId);
        }

        public int DeleteList(Guid NewId)
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
          return _newReposiotory.ExportExcel();
        }

        public IEnumerable<New> GetAll()
        {
            return _newReposiotory.GetAll();
        }

        public New GetById(Guid NewCategoryId)
        {
            return _newReposiotory.GetById(NewCategoryId);
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status,Guid? newCategoryId)
        {
            return _newReposiotory.Paging(searchName,pageSize,pageIndex,status,newCategoryId);
        }

        public int Update(Guid NewId, NewRequest request)
        {
            return _newReposiotory.Update(NewId,request);
        }
    }
}
