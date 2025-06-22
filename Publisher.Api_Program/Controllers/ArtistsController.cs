using Microsoft.AspNetCore.Mvc;
using Publisher.Domain.Dtos;
using Publisher.Domain.Models;
using Publisher.Domain.Repositories;


namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;

        // Dependency Injection af repository
        public ArtistsController(IArtistRepository artistRepo)
        {
            _artistRepo = artistRepo;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<List<ArtistDto>>> GetArtists()
        {
            var artists = await _artistRepo.GetAllAsync();

            var artistDtos = artists.Select(artist => new ArtistDto
            {
                ArtistId = artist.ArtistId,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                ArtistCovers = artist.ArtistCovers.Select(ac => new ArtistCoverShortDto
                {
                    CoverId = ac.CoverId,
                    CoverTitle = ac.Cover?.Title
                }).ToList()
            }).ToList();

            return Ok(artistDtos);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtistById(int id)
        {
            var artist = await _artistRepo.GetByIdAsync(id);

            if (artist == null)
                return NotFound();

            var artistDto = new ArtistDto
            {
                ArtistId = artist.ArtistId,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                ArtistCovers = artist.ArtistCovers.Select(ac => new ArtistCoverShortDto
                {
                    CoverId = ac.CoverId,
                    CoverTitle = ac.Cover?.Title
                }).ToList()
            };

            return Ok(artistDto);
        }

        // POST: api/Artists
        [HttpPost]
        public async Task<ActionResult<ArtistDto>> AddArtist(CreateArtistDto dto)
        {
            if (dto == null)
                return BadRequest();

            var newArtist = new Artist
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            await _artistRepo.AddAsync(newArtist);

            var artistDto = new ArtistDto
            {
                ArtistId = newArtist.ArtistId,
                FirstName = newArtist.FirstName,
                LastName = newArtist.LastName,
                ArtistCovers = new List<ArtistCoverShortDto>()
            };

            return CreatedAtAction(nameof(GetArtistById), new { id = newArtist.ArtistId }, artistDto);
        }

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, CreateArtistDto dto)
        {
            var artist = await _artistRepo.GetByIdAsync(id);
            if (artist == null)
                return NotFound();

            artist.FirstName = dto.FirstName;
            artist.LastName = dto.LastName;

            await _artistRepo.UpdateAsync(artist);

            return NoContent();
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistRepo.GetByIdAsync(id);
            if (artist == null)
                return NotFound();

            await _artistRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
