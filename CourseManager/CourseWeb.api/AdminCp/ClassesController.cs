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
    public class ClassesController : ControllerBase
    {
        private IClassRepository _classrepository;
        private IClassService _classService;
        public ClassesController(IClassService classService,IClassRepository classRepository)
        {
            _classrepository = classRepository;
            _classService = classService;
        }
        // GET: api/<ClassesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classService.GetAll());
        }

        // GET api/<ClassesController>/5
        [HttpGet("{ClassId}")]
        public IActionResult Get(Guid ClassId)
        {
            return Ok(_classService.GetById(ClassId));
        }

        // POST api/<ClassesController>
        [HttpPost]
        public IActionResult Post(ClassRequest request)
        {
          
            return StatusCode(201,_classService.Create(request));
        }

        // PUT api/<ClassesController>/5
        [HttpPut("{ClassId}")]
        public IActionResult Put(Guid ClassId,ClassRequest request)
        {
            return Ok(_classService.Update(ClassId,request));
        }

        // DELETE api/<ClassesController>/5
        [HttpDelete("{ClassId}")]
        public IActionResult Delete(Guid ClassId)
        {
            return Ok(_classService.Delete(ClassId));
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchName, int pageSize, int pageIndex, bool? status)
        {
            return Ok(_classService.Paging( searchName,  pageSize,  pageIndex,   status));
        }

    }
}
