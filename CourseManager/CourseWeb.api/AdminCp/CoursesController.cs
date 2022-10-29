using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private ICourseRepository _courseRepository;
        private readonly IWebHostEnvironment _env;
        public CoursesController(ICourseService courseService,ICourseRepository courseRepository, IWebHostEnvironment env)
        {
            _courseRepository = courseRepository;
            _courseService = courseService;
            _env = env;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseService.GetAll());
        }

        // GET api/<CoursesController>/5
        [HttpGet("{CourseId}")]
        public IActionResult Get(Guid CourseId)
        {
            return Ok(_courseService.GetById(CourseId));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public IActionResult Post(CourseRequest request)
        {
            return Ok(_courseService.Create(request));
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{CourseId}")]
        public IActionResult Put(Guid CourseId, [FromBody] CourseRequest request)
        {
            return Ok(_courseService.Update(CourseId,request));
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{CourseId}")]
        public IActionResult Delete(Guid CourseId)
        {
            return Ok(_courseService.Delete(CourseId));
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status, Guid? courseCategoryId,Guid? teacherId)
        {
            var res = _courseService.Paging(searchName, searchCode, pageSize, pageIndex, status, courseCategoryId,teacherId);
            return Ok(res);
        }
        [HttpPost("UploadPhotos")]
        public IActionResult UploadPhotos()
        {
            var httpRequest = Request.Form;
            var posted = httpRequest.Files[0];
            string filename = posted.FileName.ToString();
            var physicalPath = _env.ContentRootPath + "/Upload/Files/" + Path.GetFileName(filename);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                posted.CopyTo(stream);
            }
            return new JsonResult(filename);
        }
    }
}
