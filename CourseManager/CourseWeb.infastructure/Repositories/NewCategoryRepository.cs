using CourseWeb.Core;
using CourseWeb.Core.Entities;
using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using Microsoft.Extensions.Configuration;
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
    public class NewCategoryRepository : INewCategoryRepository
    {

        private CourseManagerContext _courseManagerContext;
        public NewCategoryRepository(CourseManagerContext courseManagerContext)
        {

            _courseManagerContext = courseManagerContext;
        }

        public int Create(NewCategoryRequest request)
        {
            NewCategory newcategory = new NewCategory()
            {
                NewCategoryId = Guid.NewGuid(),
                NewCategoryCode = request.NewCategoryCode,
                NewCategoryName = request.NewCategoryCode,
                Description = request.Description,
                Status = request.Status,
                Createdate = DateTime.Now,
                CreateBy = "Admin",
            };
            _courseManagerContext.NewCategories.Add(newcategory);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int Delete(Guid NewCategoryId)
        {
            var newCategory = _courseManagerContext.NewCategories.Find(NewCategoryId);
            if (newCategory == null)
            {
                return -1;
            }
            _courseManagerContext.NewCategories.Remove(newCategory);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }

        public int DeleteList(Guid NewCategoryId)
        {
            throw new NotImplementedException();
        }





        public IEnumerable<NewCategory> GetAll()
        {
            var rs = _courseManagerContext.NewCategories;
            return rs;
        }

        public NewCategory GetById(Guid NewCategoryId)
        {
            return _courseManagerContext.NewCategories.FirstOrDefault(x => x.NewCategoryId == NewCategoryId);
        }

        public object Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status)
        {
            var result = from t1 in _courseManagerContext.NewCategories select t1;
            if (!string.IsNullOrEmpty(searchName))
                result = result.Where(x => x.NewCategoryName.Contains(searchName));
            if (!string.IsNullOrEmpty(searchCode))
                result = result.Where(x => x.NewCategoryCode.Contains(searchCode));
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
                Data = result.ToList(),
             
            };
            return model;
        }



        public int Update(Guid NewCategoryId, NewCategoryRequest request)
        {
            NewCategory newcategory = _courseManagerContext.NewCategories.Find(NewCategoryId);
            if (newcategory == null) return -1;

            newcategory.NewCategoryCode = request.NewCategoryCode;
            newcategory.NewCategoryName = request.NewCategoryName;
            newcategory.Description = request.Description;
            newcategory.Status = request.Status;
            newcategory.UpdateBy = "leader";
            newcategory.UpdateDate = DateTime.Now;
            _courseManagerContext.NewCategories.Update(newcategory);
            var res = _courseManagerContext.SaveChanges();
            return res;
        }
        public Stream ExportExcel()
        {
            var rs = GetAll();
            var stream = new MemoryStream();
            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\CourseWeb.Api\ExcelTemplate\Danh_sach_nhan_vien.xlsx"));
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
                    sheet.Cells[rowId, 2].Value = row.NewCategoryCode;
                    sheet.Cells[rowId, 3].Value = row.NewCategoryName;
                    sheet.Cells[rowId, 4].Value = row.Status;
                    sheet.Cells[rowId, 5].Value = row.Description;
                    sheet.Cells[rowId, 6].Value = row.Createdate;
                    sheet.Cells[rowId, 7].Value = row.CreateBy;
                    stt++;
                    rowId++;
                }
                stream = new MemoryStream(package.GetAsByteArray());
            }
            stream.Position = 0;
            return stream;
            
        }

 

     
    }
}
