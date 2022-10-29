

using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Infastructure.Repositories
{
    public class NewRepository : INewReposiotory
    {

        private CourseManagerContext _courseManagerContext;
        private IStorageRepository _storageRepository;
        public NewRepository(CourseManagerContext courseManagerContext, IStorageRepository storageRepository)
        {

            _courseManagerContext = courseManagerContext;
            _storageRepository = storageRepository;
        }
        public int Create(NewRequest request)
        {
            New obj = new New()
            {
                NewId = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Detail = request.Detail,
                NewCategoryId = request.NewCategoryId,

                CreateDate = DateTime.Now,
                CreateBy = "Admin",
                Status = request.Status,
                Type = request.Type,
                Image = request.Image
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
            _courseManagerContext.News.Add(obj);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
     

        public int Delete(Guid NewId)
        {
           var obj= _courseManagerContext.News.Find(NewId);
            _courseManagerContext.News.Remove(obj);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int DeleteList(Guid NewId)
        {
            throw new NotImplementedException();
        }

        public Stream ExportExcel()
        {
            var rs = from t1 in _courseManagerContext.News
                     select new
                     {
                         t1.NewCategory.NewCategoryName,
                         t1.Title,
                         t1.NewId,
                         t1.Status,
                         t1.NewCategoryId,
                         t1.CreateDate,
                         t1.Image,
                         t1.Type,
                         t1.CreateBy,
                         t1.UpdateDate,
                         t1.UpdateBy,
                         t1.Detail,
                         t1.Description
                     };
            var stream = new MemoryStream();
            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\CourseWeb.Api\ExcelTemplate\Danh_sach_TT.xlsx"));
            FileInfo existingFile = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                // đổ dữ liệu vào sheet

                int rowId = 4;
                int stt = 1;
                foreach (var row in rs)
                {
                    sheet.Cells[rowId, 1].AutoFitColumns(10, 10);
                    for (int i = 1; i <= 9; i++)
                    {
                        // Thêm border cho cột
                        sheet.Cells[rowId, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        // Thêm width vs height cho cột
                        sheet.Cells[rowId, i + 1].AutoFitColumns(20, 20);
                        sheet.Cells[rowId, i + 1].Merge = true;
                    }
                    sheet.Cells[rowId, 1].Value = stt;
                    sheet.Cells[rowId, 2].Value = row.NewCategoryName;
                    sheet.Cells[rowId, 3].Value = row.Title;
                    sheet.Cells[rowId, 4].Value = row.Status;
                    sheet.Cells[rowId, 5].Value = row.Description;
                    sheet.Cells[rowId, 7].Value = row.Image;
                    sheet.Cells[rowId, 6].Value = row.CreateDate;
                    sheet.Cells[rowId, 7].Value = row.CreateBy;
                    stt++;
                    rowId++;
                }
                stream = new MemoryStream(package.GetAsByteArray());
            }
            stream.Position = 0;
            return stream;
        }

        public IEnumerable<New> GetAll()
        {
            var res = _courseManagerContext.News;
            return res;
        }

        public New GetById(Guid NewId)
        {
            var res = _courseManagerContext.News.Find(NewId);
            return res;
        }

        public object Paging(string searchName, int pageSize, int pageIndex, bool? status,Guid? newCategoryId)
        {
            var result = from t1 in _courseManagerContext.News
                         select new
                         {
                             t1.NewCategory.NewCategoryName,
                             t1.Title,
                             t1.NewId,
                             t1.Status,
                             t1.NewCategoryId,
                             t1.CreateDate,
                             t1.Image,
                             t1.Type,
                             t1.CreateBy,
                             t1.UpdateDate,
                             t1.UpdateBy,
                             t1.Detail,
                             t1.Description
                         };
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.Title.Contains(searchName));
            if (status != null)
            {
                result = result.Where(x => x.Status == status);
            }
            if (newCategoryId != null)
            {
                result = result.Where(x => x.NewCategoryId == newCategoryId);
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

        public int Update(Guid NewId, NewRequest request)
        {
            New obj = _courseManagerContext.News.Find(NewId);

            obj.Title = request.Title;
            obj.Description = request.Description;
            obj.Detail = request.Detail;
            obj.NewCategoryId = request.NewCategoryId;
            obj.UpdateDate = DateTime.Now;
            obj.UpdateBy = "Admin 1";
            obj.Status = request.Status;
            obj.Type = request.Type;
            obj.Image = request.Image;
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
    }
}
