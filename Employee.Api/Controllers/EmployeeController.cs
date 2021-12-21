using EmployeeApi.Model;
using EmployeeApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepo.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{EmployeeID}")]
        public async Task<IActionResult> GetEmployee(int EmployeeID)
        {
            try
            {
                var employees = await _employeeRepo.GetEmployee(EmployeeID); 
                if(employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{EmployeeID}")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeID)
        {
            try
            {
                var employees = await _employeeRepo.GetEmployee(EmployeeID); 
                if(employees == null)
                {
                    return NotFound();
                }
                await _employeeRepo.DeleteEmployee(EmployeeID);
                return NoContent();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                var createEmployee = await _employeeRepo.CreateEmployee(employee);
                return Ok(createEmployee); 
            }catch(Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut("{EmployeeID}")]
        public async Task<IActionResult> UpdateEmployee(int EmployeeID, Employee employee)
        {
            try
            {
                var employeeId = await _employeeRepo.GetEmployee(EmployeeID);
                if (employeeId == null)
                {
                    return NotFound();
                }
                var updateEmployee = await _employeeRepo.UpdateEmployee(EmployeeID, employee);
                return CreatedAtRoute(
                    new
                    {
                        updateEmployee.EmployeeName,
                        updateEmployee.EmployeeAddress,
                        updateEmployee.PhoneNumber
                    },
                    updateEmployee);
            }catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        
    }
}
