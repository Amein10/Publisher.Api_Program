using Microsoft.AspNetCore.Mvc;
using Publisher.Domain.Dtos;
using Publisher.Domain.Models;
using Publisher.Domain.Repositories;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverController : ControllerBase
    {
        private readonly ICoverRepository _coverRepo;

        public CoverController(ICoverRepository coverRepo)
        {
            _coverRepo = coverRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CoverDto>>> GetCovers()
        {
            var covers = await _coverRepo.GetAllAsync();

            var coverDtos = covers.Select(cover => new CoverDto
            {
                CoverId = cover.CoverId,
                Title = cover.Title,
                DigitalOnly = cover.DigitalOnly,
                BookId = cover.BookId,
                BookTitle = cover.Book?.Title,
                Artists = cover.ArtistCovers.Select(ac => new CoverArtistShortDto
                {
                    ArtistId = ac.ArtistId,
                    FirstName = ac.Artist?.FirstName,
                    LastName = ac.Artist?.LastName
                }).ToList()
            }).ToList();

            return Ok(coverDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoverDto>> GetCoverById(int id)
        {
            var cover = await _coverRepo.GetByIdAsync(id);

            if (cover == null)
                return NotFound();

            var coverDto = new CoverDto
            {
                CoverId = cover.CoverId,
                Title = cover.Title,
                DigitalOnly = cover.DigitalOnly,
                BookId = cover.BookId,
                BookTitle = cover.Book?.Title,
                Artists = cover.ArtistCovers.Select(ac => new CoverArtistShortDto
                {
                    ArtistId = ac.ArtistId,
                    FirstName = ac.Artist?.FirstName,
                    LastName = ac.Artist?.LastName
                }).ToList()
            };

            return Ok(coverDto);
        }

        [HttpPost]
        public async Task<ActionResult<CoverDto>> AddCover(CreateCoverDto dto)
        {
            if (dto == null)
                return BadRequest();

            var newCover = new Cover
            {
                Title = dto.Title,
                DigitalOnly = dto.DigitalOnly,
                BookId = dto.BookId
            };

            await _coverRepo.AddAsync(newCover);

            var coverDto = new CoverDto
            {
                CoverId = newCover.CoverId,
                Title = newCover.Title,
                DigitalOnly = newCover.DigitalOnly,
                BookId = newCover.BookId,
                BookTitle = null,
                Artists = new List<CoverArtistShortDto>()
            };

            return CreatedAtAction(nameof(GetCoverById), new { id = newCover.CoverId }, coverDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCover(int id, CreateCoverDto dto)
        {
            var cover = await _coverRepo.GetByIdAsync(id);
            if (cover == null)
                return NotFound();

            cover.Title = dto.Title;
            cover.DigitalOnly = dto.DigitalOnly;
            cover.BookId = dto.BookId;

            await _coverRepo.UpdateAsync(cover);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCover(int id)
        {
            var cover = await _coverRepo.GetByIdAsync(id);
            if (cover == null)
                return NotFound();

            await _coverRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
