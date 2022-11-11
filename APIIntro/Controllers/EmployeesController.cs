using API_Intro.DAL;
using API_Intro.Entities;
using APIIntro.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        AppDbContext _context { get; }
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDTO emp)
        {
            await _context.Employees.AddAsync(new()
            {
                Name = emp.Name,
                Surname = emp.Surname,
                Age = emp.Age,
                DepartmentId = emp.DepartmentId,
            });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee is null) return NotFound();
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}/update")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromRoute] EmployeeUpdateDTO emp)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee is null) return NotFound();
            employee.Name = emp.Name is null ? employee.Name : emp.Name;
            employee.Surname = emp.Surname is null ? employee.Surname : emp.Surname;
            employee.Age = emp.Age;
            employee.DepartmentId = emp.DepartmentId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
