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

                emp.Id = Guid.NewGuid();
                await _dbContext.Employees.AddAsync(emp);
                await _dbContext.SaveChangesAsync();
                return Ok("Ekleme işlemi başarılı!");
            }
            else
                return BadRequest("???");

            //daha önce bu mail adresiyle ilgili bir kayıt var mı kontrol et?

            //1- kayıt varsa kullanıcı kayıtlı diyerek eklemeden geri döndür

            //2- kayıt yoksa kullanıcıyı kaydet           
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

            emp.Name = updateEmp.Name;
            emp.Email = updateEmp.Email;
            emp.Phone = updateEmp.Phone;
            emp.Salary = updateEmp.Salary;
            emp.Department = updateEmp.Department;
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
