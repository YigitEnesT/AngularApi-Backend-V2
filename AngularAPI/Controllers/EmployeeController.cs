using AngularAPI.Data;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace AngularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly AngularAPIDbContext _dbContext;
        public EmployeeController(AngularAPIDbContext _dbContext) 
        {
            this._dbContext = _dbContext;
        }
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetAllEmployees()
        {

            var results = await _dbContext.Employees.OrderBy(x => x.Order).ToListAsync();
            return Ok(results);
        }
        [HttpPost("PostEmployee")]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var userExists = _dbContext.Employees.FirstOrDefault(x => x.Email == emp.Email);
                if (userExists != null)
                {
                    return BadRequest("Kullanıcı zaten kayıtlı");
                }
                var userExists2 = _dbContext.Employees.FirstOrDefault(y => y.Order == emp.Order);
                if (userExists2 != null)
                {
                    return BadRequest("Aynı order sırasına sahip bir kayıt var!");
                }
                emp.Department=emp.Department.ToUpper();

                emp.Id = Guid.NewGuid();
                await _dbContext.Employees.AddAsync(emp);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Başarısız işlem");
            }    
        }

        [HttpGet("GetIdEmployee")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPut("UpdateEmployee")]

        public async Task<IActionResult> PutEmployee(Guid id, Employee updateEmp)
        {

            var emp = await _dbContext.Employees.FindAsync(updateEmp.Id);
            if (emp == null)
            {
                return NotFound();
            }

            var userExitst = _dbContext.Employees.FirstOrDefault(x => x.Email == updateEmp.Email && x.Id != updateEmp.Id);
            if (userExitst != null)
            {
                return BadRequest("Bu mail adresi başkası tarafından kullanılmakta!");
            }

            var userExist2 = _dbContext.Employees.FirstOrDefault(y =>  y.Order == updateEmp.Order && y.Id != updateEmp.Id);
            if(userExist2 != null)
            {
                return BadRequest("Aynı Order değerine sahip başka bir kullanıcı var!");
               
            }
            


            emp.Name = updateEmp.Name;
            emp.Email = updateEmp.Email;
            emp.Phone = updateEmp.Phone;
            emp.Salary = updateEmp.Salary;
            emp.Department = updateEmp.Department.ToUpper();
            emp.Order = updateEmp.Order;

            await _dbContext.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var emp = await _dbContext.Employees.FindAsync(id);
            if(emp == null)
            {
                return NotFound();
            }
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Ok(emp);
        }
    }
}
