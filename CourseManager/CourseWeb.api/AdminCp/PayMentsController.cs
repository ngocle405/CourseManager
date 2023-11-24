using CourseWeb.Core.Interfaces.Services;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Authorization;
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
    public class PayMentsController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PayMentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        // GET: api/<PayMentsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<PayMentsController>/5
        [HttpGet("{paymentId}")]
        public IActionResult Get(Guid paymentId)
        {

            return Ok(_paymentService.GetById(paymentId));
        }

        // POST api/<PayMentsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(PaymentRequest request)
        {
            return StatusCode(201, _paymentService.Create(request));
        }

        // PUT api/<PayMentsController>/5
        [HttpPut("{paymentId}")]
        [Authorize]
        public IActionResult Put(Guid paymentId ,PaymentRequest request)
        {
            return Ok(_paymentService.Update(paymentId, request));
        }

        // DELETE api/<PayMentsController>/5
        [HttpDelete("{paymentId}")]
        [Authorize]
        public IActionResult  Delete(Guid paymentId)
        {
            return Ok(_paymentService.Delete(paymentId));
        }

        [HttpGet("Paging")]
        [Authorize]
        public IActionResult Paging(string searchName, int pageSize, int pageIndex, bool? status, Guid? courseId)
        {
            return Ok(_paymentService.Paging(searchName, pageSize, pageIndex, status, courseId));
        }
    }
}
