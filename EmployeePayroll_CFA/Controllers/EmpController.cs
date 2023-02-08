using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayroll_CFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpBL iempBL;

        public EmpController(IEmpBL iempBL)
        {
            this.iempBL = iempBL;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult RegisterEmp(EmpoyeeRegi employeeRegi)
        {
            try
            {
                var result = iempBL.Registration(employeeRegi);
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
                var result = iempBL.Login(loginModel);
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
