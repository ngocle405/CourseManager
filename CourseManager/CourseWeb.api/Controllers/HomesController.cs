using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWeb.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private ICourseService _courseService;
        private ITeacherService _teacherService;
        private ICourseCategoryService _courseCategoryService;
        private IStudentService _studentService;
        private INewService _newService;
        public HomesController(IStudentService studentService,ICourseService courseService,ITeacherService teacherService,ICourseCategoryService courseCategoryService,INewService newService)
        {
            _newService = newService;
            _courseService = courseService;
            _teacherService = teacherService;
            _courseCategoryService = courseCategoryService;
            _studentService = studentService;
     
        }
        [HttpGet("listCourse")]
        public IActionResult ListCourse()
        {
            return Ok(_courseService.GetAll());
        }
       
        [HttpGet("listCourseCategory")]
        public IActionResult ListCourseCategory()
        {
            var res = _courseCategoryService.GetAll();
            return Ok(res);
        }
        //
        [HttpGet("findByCourse/{courseId}")]
        public IActionResult FindByCourse(Guid courseId)
        {
            var res = _courseService.GetById(courseId);
            return Ok(res);
        }
        [HttpGet("teacher-list")]
        public IActionResult TeacherList()
        {
            var res = _teacherService.GetAll();
            return Ok(res);
        }
        [HttpGet("finbyTeacher/{teacherId}")]
        public IActionResult FinbyTeacher(Guid teacherId)
        {
            var res = _teacherService.GetById(teacherId);
            return Ok(res);
        }
        [HttpPost("Register")]
        public IActionResult CreateRegister(StudentRequest request)
        {
            var res = _studentService.Create(request);
            return Ok(res);
        }
        [HttpGet("new-list")]
        public IActionResult NewList()
        {
            var res = _newService.GetAll();
            return Ok(res);
        }
        [HttpGet("find-by-new/{newId}")]
        public IActionResult FinbyNew(Guid newId)
        {
            var res = _newService.GetById(newId);
            return Ok(res);
        }

    }
}
