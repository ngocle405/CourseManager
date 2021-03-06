using CourseWeb.Core.Interfaces.Repositories;
using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWeb.api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeacherRepository _teacherRepository;
        private ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService,ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _teacherService = teacherService;
        }
        // GET: api/<TeachersController>
        [HttpGet]
        public IActionResult  Get()
        {
            return Ok(_teacherService.GetAll());
        }

        // GET api/<TeachersController>/5
        [HttpGet("{teacherId}")]
        public IActionResult Get(Guid teacherId)
        {
            var res = _teacherService.GetById(teacherId);
               return Ok(res);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public IActionResult Post([FromBody] TeacherRequest request)
        {
           
            var entitis = _teacherService.Create(request);
            return StatusCode(201, entitis);
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{teacherId}")]
        public IActionResult Put(Guid teacherId, [FromBody] TeacherRequest request)
        {
            var res = _teacherService.Update(teacherId, request);
            return Ok(res);
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{teacherId}")]
        public IActionResult Delete(Guid teacherId)
        {
            var res = _teacherService.Delete(teacherId);
            return Ok(res);
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchName, string searchCode, int pageSize, int pageIndex, bool? status)
        {
            var res = _teacherService.Paging(searchName, searchCode, pageSize, pageIndex, status);
            return Ok(res);
        }
    }
}
