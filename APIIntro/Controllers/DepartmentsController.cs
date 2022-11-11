using API_Intro.DAL;
using API_Intro.Entities;
using APIIntro.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        AppDbContext _context { get; }
        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            return Ok(await _context.Departments.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentCreateDTO dprt)
        {
            await _context.Departments.AddAsync(new()
            {
                Name = dprt.Name
            });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch ("{id}/update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody]DepartmentUpdateDTO dprt)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department is null) return NotFound();
            department.Name = dprt.Name is null ? department.Name : dprt.Name;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete ("{id}/delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department is null) return NotFound();
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "Student delete",
                StatusCode = StatusCodes.Status200OK,
                department.Id
            });
        }
    }
}
