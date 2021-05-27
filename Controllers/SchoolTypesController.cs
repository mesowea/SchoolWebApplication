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
    public class SchoolTypesController : ControllerBase
    {
        private readonly SchoolWebApplicationContext _context;

        public SchoolTypesController(SchoolWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/SchoolTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolType>>> GetSchoolTypes()
        {
            return await _context.SchoolTypes.ToListAsync();
        }

        // GET: api/SchoolTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolType>> GetSchoolType(int id)
        {
            var schoolType = await _context.SchoolTypes.FindAsync(id);

            if (schoolType == null)
            {
                return NotFound();
            }

            return schoolType;
        }

        // PUT: api/SchoolTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolType(int id, SchoolType schoolType)
        {
            if (id != schoolType.Id)
            {
                return BadRequest();
            }

            _context.Entry(schoolType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolTypeExists(id))
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

        // POST: api/SchoolTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolType>> PostSchoolType(SchoolType schoolType)
        {
            _context.SchoolTypes.Add(schoolType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolType", new { id = schoolType.Id }, schoolType);
        }

        // DELETE: api/SchoolTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolType(int id)
        {
            var schoolType = await _context.SchoolTypes.FindAsync(id);
            if (schoolType == null)
            {
                return NotFound();
            }

            _context.SchoolTypes.Remove(schoolType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolTypeExists(int id)
        {
            return _context.SchoolTypes.Any(e => e.Id == id);
        }
    }
}
