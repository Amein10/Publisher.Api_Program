using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController(PublisherDbContext context) : ControllerBase
    {
        private readonly PublisherDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Artist>>> GetArtists()
        {
            return Ok(await _context.Artists.Include(a => a.ArtistLinks).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            var artist = await _context.Artists
                .Include(a => a.ArtistLinks)
                .ThenInclude(al => al.Cover)
                .FirstOrDefaultAsync(a => a.ArtistId == id);

            if (artist == null)
                return NotFound();

            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> AddArtist(Artist newArtist)
        {
            if (newArtist == null)
                return BadRequest();

            _context.Artists.Add(newArtist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArtistById), new { id = newArtist.ArtistId }, newArtist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, Artist updatedArtist)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
                return NotFound();

            artist.FirstName = updatedArtist.FirstName;
            artist.LastName = updatedArtist.LastName;
            // Du kan tilføje flere felter her hvis det bliver nødvendigt.

            await _context.SaveChangesAsync();

            return Ok(artist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
                return NotFound();

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return Ok(artist);
        }
    }
}
