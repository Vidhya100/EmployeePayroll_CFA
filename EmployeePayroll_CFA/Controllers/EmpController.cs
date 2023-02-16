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
        public IActionResult AddEmp( EmpModel empModel)
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
                    return Ok(new { success = true, message = "Fetched Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable to get list." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(long empId, EmpModel empModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iempBL.UpdateEmp(empId, userId, empModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Not get updated try again." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteEmp(long empId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iempBL.DeleteEmp(empId, userId);
                if (result == true)
                {
                    return Ok(new { success = true, message = "Deleted Successfully", data = result });
                }
                else
                {
                   return BadRequest(new { success = false, message = "Not Deleted." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
