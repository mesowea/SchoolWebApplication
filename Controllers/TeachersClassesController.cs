using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebApplication.Models;

namespace SchoolWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersClassesController : ControllerBase
    {
        private readonly SchoolWebApplicationContext _context;

        public TeachersClassesController(SchoolWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TeachersClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachersClasses>>> GetTeachersClasses()
        {
            return await _context.TeachersClasses.ToListAsync();
        }

        // GET: api/TeachersClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeachersClasses>> GetTeachersClasses(int id)
        {
            var teachersClasses = await _context.TeachersClasses.FindAsync(id);

            if (teachersClasses == null)
            {
                return NotFound();
            }

            return teachersClasses;
        }

        // PUT: api/TeachersClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachersClasses(int id, TeachersClasses teachersClasses)
        {
            if (id != teachersClasses.Id)
            {
                return BadRequest();
            }

            _context.Entry(teachersClasses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersClassesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeachersClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeachersClasses>> PostTeachersClasses(TeachersClasses teachersClasses)
        {
            _context.TeachersClasses.Add(teachersClasses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachersClasses", new { id = teachersClasses.Id }, teachersClasses);
        }

        // DELETE: api/TeachersClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachersClasses(int id)
        {
            var teachersClasses = await _context.TeachersClasses.FindAsync(id);
            if (teachersClasses == null)
            {
                return NotFound();
            }

            _context.TeachersClasses.Remove(teachersClasses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeachersClassesExists(int id)
        {
            return _context.TeachersClasses.Any(e => e.Id == id);
        }
    }
}
