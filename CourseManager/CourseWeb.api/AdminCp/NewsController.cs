
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CourseWeb.Api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewService _newService;
        public NewsController(INewService newService)
        {
            _newService = newService;
        }
        [HttpPost]
       
        public IActionResult Create(NewRequest newRequest)
        {
            var res= _newService.Create(newRequest);
            return StatusCode(201,res);
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchName, int pageSize, int pageIndex, bool? status, Guid? newCategoryId)
        {
            return Ok(_newService.Paging(searchName, pageSize, pageIndex, status,newCategoryId));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_newService.GetAll());
        }
        [HttpDelete("{newId}")]
        public IActionResult Delete(Guid newid)
        {
            return Ok(_newService.Delete(newid));
        }
        [HttpPut("{newId}")]
        public IActionResult Update(Guid newId, NewRequest newRequest)
        {
            return Ok(_newService.Update(newId, newRequest));
        }
        [HttpGet("{newId}")]
        public IActionResult GetById(Guid newId)
        {
            return Ok(_newService.GetById(newId));
        }
        [HttpGet("export")]
        public IActionResult ExportExcel()
        {
            var res = _newService.ExportExcel();
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
