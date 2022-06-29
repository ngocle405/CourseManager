using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWeb.Api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController : ControllerBase
    {
        private readonly ICourseCategoryService _courseCategoryService;
        public CourseCategoriesController(ICourseCategoryService courseCategoryService)
        {
            _courseCategoryService = courseCategoryService;
        }
        // GET: api/<CourseCategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseCategoryService.GetAll());
        }

        // GET api/<CourseCategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_courseCategoryService.GetById(id));
        }

        // POST api/<CourseCategoriesController>
        [HttpPost]
        public IActionResult Post(CourseCategoryRequest  request)
        {
            return StatusCode(201, _courseCategoryService.Create(request));
        }

        // PUT api/<CourseCategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, CourseCategoryRequest request)
        {
            return Ok(_courseCategoryService.Update(id,request));
        }

        // DELETE api/<CourseCategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_courseCategoryService.Delete(id));
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status)
        {
            return Ok(_courseCategoryService.Paging(searchName,searchCode,pageSize,pageIndex,status));
        }
    }
}
