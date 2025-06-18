using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController(PublisherDbContext context) : ControllerBase
    {
        private readonly PublisherDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Cover>>> GetCovers()
        {
            return Ok(await _context.Covers
                .Include(c => c.Book)
                .Include(c => c.ArtistCovers)
                    .ThenInclude(al => al.Artist)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cover>> GetCoverById(int id)
        {
            var cover = await _context.Covers
                .Include(c => c.Book)
                .Include(c => c.ArtistCovers)
                    .ThenInclude(al => al.Artist)
                .FirstOrDefaultAsync(c => c.CoverId == id);

            if (cover == null)
                return NotFound();

            return Ok(cover);
        }

        [HttpPost]
        public async Task<ActionResult<Cover>> AddCover(Cover newCover)
        {
            if (newCover == null)
                return BadRequest();

            _context.Covers.Add(newCover);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoverById), new { id = newCover.CoverId }, newCover);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCover(int id, Cover updatedCover)
        {
            var cover = await _context.Covers.FindAsync(id);
            if (cover == null)
                return NotFound();

            cover.Title = updatedCover.Title;
            cover.DigitalOnly = updatedCover.DigitalOnly;
            cover.BookId = updatedCover.BookId;
            // Opdater evt. ArtistLinks her hvis nødvendigt (ellers håndteres det separat)

            await _context.SaveChangesAsync();

            return Ok(cover);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCover(int id)
        {
            var cover = await _context.Covers.FindAsync(id);
            if (cover == null)
                return NotFound();

            _context.Covers.Remove(cover);
            await _context.SaveChangesAsync();

            return Ok(cover);
        }
    }
}
