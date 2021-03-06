using CourseWeb.Core;
using CourseWeb.Core.Entities;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWeb.api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private CourseManagerContext _courseManagerContext;
        public AdminsController(CourseManagerContext courseManagerContext)
        {
            _courseManagerContext = courseManagerContext;
        }
        [HttpPost("Login")]
        public IActionResult Login(AdminRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "UserName", msg = "Tên đăng nhập không để trống" },
                    useMsg = "Tên đăng nhập không để trống",
                    Code = 400,
                };
                return Ok( msg);
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "Password", msg = "Bạn phải nhập Mật khẩu" },
                    useMsg = "Mật khẩu không để trống",
                    Code = 400,
                };
                return Ok (msg);
            }
            var admin = _courseManagerContext.Admins.SingleOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if(admin != null)
            {
                return Ok(admin);
            }
            else
            {
                var msg = new
                {
                    useMsg = "Tài khoản hoặc mật khẩu chưa chính xác",
                    Code = 400,
                };
                return Ok(msg);
            }
          
        }
    }
}
