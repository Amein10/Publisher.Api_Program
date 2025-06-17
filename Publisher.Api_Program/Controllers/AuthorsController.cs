using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(PublisherDbContext context) : ControllerBase
    {
        private readonly PublisherDbContext _context = context;


    // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author newAuthor)
        {
            if (newAuthor == null)
                return BadRequest();

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthor.Id }, newAuthor);
        }
        // PUT: api/authors
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author updatedAuthor)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;


            await _context.SaveChangesAsync();

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return Ok(author); // <-- dette virker i Scalar
            // return NoContent();

        }



    }
}
