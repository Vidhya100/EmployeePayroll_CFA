using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmployeePayroll_CFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL iuserBL;

        public UserController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult RegisterEmp(UserRegi employeeRegi)
        {
            try
            {
                var result = iuserBL.Registration(employeeRegi);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Registered Successfully", data = result });
                }
                else
                {
                    return BadRequest(new {success= false, message = "Registration failed"});
                }
            }
            catch(System.Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser(LoginModel loginModel)
        {
            try
            {
                var result = iuserBL.Login(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login Failed." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
