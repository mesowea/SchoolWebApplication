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
    public class TeacherPostsController : ControllerBase
    {
        private readonly SchoolWebApplicationContext _context;

        public TeacherPostsController(SchoolWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TeacherPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherPost>>> GetTeacherPosts()
        {
            return await _context.TeacherPosts.ToListAsync();
        }

        // GET: api/TeacherPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherPost>> GetTeacherPost(int id)
        {
            var teacherPost = await _context.TeacherPosts.FindAsync(id);

            if (teacherPost == null)
            {
                return NotFound();
            }

            return teacherPost;
        }

        // PUT: api/TeacherPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherPost(int id, TeacherPost teacherPost)
        {
            if (id != teacherPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherPostExists(id))
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

        // POST: api/TeacherPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherPost>> PostTeacherPost(TeacherPost teacherPost)
        {
            _context.TeacherPosts.Add(teacherPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherPost", new { id = teacherPost.Id }, teacherPost);
        }

        // DELETE: api/TeacherPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherPost(int id)
        {
            var teacherPost = await _context.TeacherPosts.FindAsync(id);
            if (teacherPost == null)
            {
                return NotFound();
            }

            _context.TeacherPosts.Remove(teacherPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherPostExists(int id)
        {
            return _context.TeacherPosts.Any(e => e.Id == id);
        }
    }
}
