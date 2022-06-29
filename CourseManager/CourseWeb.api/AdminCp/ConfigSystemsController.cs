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
    public class ConfigSystemsController : ControllerBase
    {
        private IConfigSystemService _configSystemService;
        public ConfigSystemsController(IConfigSystemService configSystemService)
        {
            _configSystemService = configSystemService;
        }
        // GET: api/<ConfigSystemsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_configSystemService.GetAll());
        }

        // GET api/<ConfigSystemsController>/5
        [HttpGet("{configId}")]
        public IActionResult Get(Guid configId)
        {
            return Ok(_configSystemService.GetById(configId));
        }

        // POST api/<ConfigSystemsController>
        [HttpPost]
        public IActionResult Post([FromBody] ConfigSystemRequest  request)
        {
            return StatusCode(201,_configSystemService.Create(request));
        }

        // PUT api/<ConfigSystemsController>/5
        [HttpPut("{configId}")]
        public IActionResult Put(Guid configId, [FromBody] ConfigSystemRequest  request)
        {
            return Ok(_configSystemService.Update(configId, request));
        }

        // DELETE api/<ConfigSystemsController>/5
        [HttpDelete("{configId}")]
        public IActionResult  Delete(Guid configId)
        {
            return Ok(_configSystemService.Delete(configId));
        }
        [HttpGet("Paging")]
        public IActionResult Paging(string searchAddress, int pageSize, int pageIndex, bool? status)
        {
            return Ok(_configSystemService.Paging(searchAddress,pageSize,pageIndex,status));
        }
    }
}
