using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddEmp(EmpModel empModel)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iempBL.AddEmp(empModel, userid);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Employee Added", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Not get saved." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iempBL.GetAllEmployee(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get Notes Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable to get Note." });
                }
            }
            catch (Exception ex)
            {
                 return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
