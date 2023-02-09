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
        [Route("Create")]
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
    }
}
