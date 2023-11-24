using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWeb.Api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCategoriesController : ControllerBase
    {
        private INewCategoryService _newCategoryService;
        public NewCategoriesController(INewCategoryService newCategoryService)
        {
            _newCategoryService = newCategoryService;
        }
        // GET: api/<NewCategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_newCategoryService.GetAll());
        }

        // GET api/<NewCategoriesController>/5
        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            return Ok(_newCategoryService.GetById(id));
        }

        // POST api/<NewCategoriesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(NewCategoryRequest request)
        {

            var entities = _newCategoryService.Create(request);
            return StatusCode(201,entities);
        }

        // PUT api/<NewCategoriesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(Guid id, NewCategoryRequest request)
        {
            var entities = _newCategoryService.Update(id, request);
            return Ok(entities);
        }

        // DELETE api/<NewCategoriesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var entities = _newCategoryService.Delete(id);
            return Ok(entities);
        }
        [HttpGet("Paging")]
        [Authorize]
        public IActionResult Paging(string searchName,string searchCode, int pageSize, int pageIndex, bool? status)
        {
            var entities = _newCategoryService.Paging(searchName,searchCode,pageSize,pageIndex, status);
            return Ok(entities);
        }
        [HttpGet("export")]
        public IActionResult ExportExcel()
        {
            var rs = _newCategoryService.ExportExcel();
            // var fileName = $"DanhSachLoaiTinTuc_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";
            //return  File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            //    fileName);
            return File(rs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
