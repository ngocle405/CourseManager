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

namespace CourseWeb.infastructure.Repositories
{
    public class ConfigSystemRepository : IConfigSystemRepository
    {
        private readonly CourseManagerContext _courseManagerContext;
        private IStorageRepository _storageRepository;
        public ConfigSystemRepository(CourseManagerContext courseManagerContext,IStorageRepository storageRepository)
        {
            _courseManagerContext = courseManagerContext;
            _storageRepository = storageRepository;
        }
        public int Create(ConfigSystemRequest request)
        {
            var con = new ConfigSystem()
            {
                SystemId = Guid.NewGuid(),
                IdNo=request.IdNo,
                Phone=request.Phone,
                Status=request.Status,
                Hotline1=request.Hotline1,
                Hotline2=request.Hotline2,
                Description=request.Description,
                Address=request.Address,
                TitleDefault=request.TitleDefault,
  Information=request.Information
            };
            if (request.Image != null)
            {
                var arrData = request.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    con.Image = $"{savePath}";
                    _storageRepository.SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _courseManagerContext.ConfigSystems.Add(con);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid configId)
        {
            var config = _courseManagerContext.ConfigSystems.Find(configId);
            if (config == null)
            {
                return -1;
            }
            _courseManagerContext.ConfigSystems.Remove(config);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int DeleteList(Guid configId)
        {
            throw new NotImplementedException();
        }

        public int ExportExcel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConfigSystem> GetAll()
        {
            return _courseManagerContext.ConfigSystems;
        }

        public ConfigSystem GetById(Guid configId)
        {
            var res = _courseManagerContext.ConfigSystems.Find(configId);
            if (res == null) return null;
            return res;
        }

        public object Paging(string searchAddress, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.ConfigSystems select t1;
            if (!string.IsNullOrEmpty(searchAddress))
                result = result.Where(x => x.Address.Contains(searchAddress));
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

        public int Update(Guid configId, ConfigSystemRequest request)
        {
            var con = _courseManagerContext.ConfigSystems.Find(configId);
            con.IdNo = request.IdNo;
            con.Information = request.Information;
            con.Phone = request.Phone;
            con.Status = request.Status;
            con.Hotline1 = request.Hotline1;
            con.Hotline2 = request.Hotline2;
            con.Description = request.Description;
            con.Address = request.Address;
            con.TitleDefault = request.TitleDefault;
         
            if (request.Image != null)
            {
                var arrData = request.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $"{arrData[0]}";
                    con.Image = $"{savePath}";
                    _storageRepository.SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
    }
}
