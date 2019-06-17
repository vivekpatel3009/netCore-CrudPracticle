using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPi.BAL.Model;
using CoreAPi.BAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreTestApi.Controllers
{
   // [Produces("application/json")]
    //[Route("api/Employee")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IConfiguration _config;
        private readonly IManageEmployee _iManageEmployee;
        private readonly ImanageContryState _imanageContryState;
        public EmployeeController(IManageEmployee iManageEmployee,ImanageContryState ImanageContryState)
        {
            _iManageEmployee = iManageEmployee;
            _imanageContryState = ImanageContryState;
          //  _config = config;
        }
        [HttpPost]
        [Route("AddEdit")]
        public async Task<IActionResult> AddEdit(EmployeeBAL EmployeeBAL)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _iManageEmployee.AddEmployee(EmployeeBAL);
                    if (result == "Added")
                    {
                        return Ok(result);
                    }
                    else if (result == "Updated")
                    {
                        return Ok(result);
                    }
                    else { return NotFound(); }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await _iManageEmployee.GetById(Id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var Employees = await _iManageEmployee.GetEmployee();
                if (Employees == null)
                {
                    return NotFound();
                }
                return Ok(Employees);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteEMP")]
        public async Task<IActionResult> DeleteEMP(int? Id)
        {
            bool result = false;

            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _iManageEmployee.Remove(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetStateById")]
        public async Task<IActionResult> GetStates(int Id)
        {
            try
            {
                var ContryList = await _imanageContryState.GetStateById(Id);
                if (ContryList == null)
                {
                    return NotFound();
                }
                return Ok(ContryList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}