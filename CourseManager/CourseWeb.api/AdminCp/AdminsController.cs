using CourseWeb.Core;
using CourseWeb.Core.Entities;
using CourseWeb.Core.Models;
using CourseWeb.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.api.AdminCp
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private CourseManagerContext _courseManagerContext;
        private readonly AppSetting _appSettings;
        public AdminsController(CourseManagerContext courseManagerContext, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _courseManagerContext = courseManagerContext;
            _appSettings = optionsMonitor.CurrentValue;
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
                return Ok(msg);
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "Password", msg = "Bạn phải nhập Mật khẩu" },
                    useMsg = "Mật khẩu không để trống",
                    Code = 400,
                };
                return Ok(msg);
            }
            var admin = _courseManagerContext.Admins.SingleOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if (admin != null)
            {
                var res = new
                {
                    Code = 1000,
                    Msg = "Success",
                    Data = new
                    {
                        User = admin.UserName,
                        Permisions = new {},
                        AccessToken = GenerateToken(admin),

                    },
                };
                return Ok(res); 
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
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_courseManagerContext.Admins);
        }
        private string GenerateToken(Admin nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("UserName", nguoiDung.UserName),
                    new Claim("Id", nguoiDung.Id.ToString()),

                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        
    }


    // POST api/<ClassesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(Admin request)
        {
            request.Id =  Guid.NewGuid();
            var res = _courseManagerContext.Admins.Add(request);
            _courseManagerContext.SaveChanges();
            return Ok(res);
        }

        // PUT api/<ClassesController>/5
        [HttpPut("{Id}")]
        [Authorize]
        public IActionResult Put(Admin request)
        {
            var res = _courseManagerContext.Admins.Update(request);
            _courseManagerContext.SaveChanges();
            return Ok(res);
        }
        [HttpDelete("range")]
        [Authorize]
        public IActionResult DeleteRange(List<Guid?> request)
        {
            var entitiesToDelete = _courseManagerContext.Admins.Where(e => request.Contains(e.Id));
            _courseManagerContext.Admins.RemoveRange(entitiesToDelete);
            _courseManagerContext.SaveChanges();
            return Ok(entitiesToDelete);
        }
        [HttpPost("range")]
        [Authorize]
        public IActionResult PostRange(List<Admin> request)
        {
            foreach (var item in request)
            {
                item.Id = Guid.NewGuid();   
            }
            _courseManagerContext.Admins.AddRange(request);
            _courseManagerContext.SaveChanges();
            return StatusCode(201,request);
        }
        [HttpPut("range")]
        [Authorize]
        public IActionResult PutRange(List<Admin> request)
        {
            foreach (var item in request)
            {
                if (item.Id == null)
                {
                   item.Id = Guid.NewGuid();
                }
            }
            //var entitiesToDelete = _courseManagerContext.Admins.Where(e => request.);
            _courseManagerContext.Admins.UpdateRange(request);
            _courseManagerContext.SaveChanges();
            return Ok(request);
        }

    }
}
