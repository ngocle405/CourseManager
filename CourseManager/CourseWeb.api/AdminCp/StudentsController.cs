using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWeb.api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        private IStudentService _studentService;
        private readonly IWebHostEnvironment _env;
        public StudentsController(IStudentService studentService, IStudentRepository studentRepository,  IWebHostEnvironment env)
        {
            _studentRepository = studentRepository;
            _studentService = studentService;
            _env = env;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{studentId}")]
  
        public IActionResult Get(Guid studentId)
        {
            return Ok(_studentService.GetById(studentId));
        }

        // POST api/<StudentsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(StudentRequest request)
        {
            return StatusCode(201,_studentService.Create(request));
        }
        [HttpGet("Register")]
        public IActionResult ListRegister(string searchName, int pageSize, int pageIndex, bool? status)
        {
            return Ok(_studentService.ListRegister(searchName, pageSize, pageIndex, status));
        }
        // PUT api/<StudentsController>/5
        [HttpPut("{studentId}")]
        [Authorize]
        public IActionResult Put(Guid studentId,  StudentRequest request)
        {
            return Ok(_studentService.Update(studentId,request));
        }
        [HttpPut("updateStatus/{studentId}")]
        [Authorize]
        public IActionResult UpdateStatus(Guid studentId, StudentRequest request)
        {
            return Ok(_studentService.ChangeStatus(studentId, request));
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{studentId}")]
        [Authorize]
        public IActionResult Delete(Guid studentId)
        {
            return Ok(_studentService.Delete(studentId));
        }
        [HttpGet("Paging")]
        [Authorize]
        public IActionResult Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status, Guid? courseId,Guid? classId)
        {
            return Ok(_studentService.Paging(searchName, searchCode, pageSize, pageIndex, status, courseId,classId));
        }
        [HttpPost("UploadPhotos")]
        [Authorize]
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
