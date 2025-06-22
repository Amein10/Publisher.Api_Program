using Microsoft.AspNetCore.Mvc;
using Publisher.Domain.Dtos;
using Publisher.Domain.Models;
using Publisher.Domain.Repositories;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorRepo.GetAllAsync();

            var authorDtos = authors.Select(author => new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = author.Books.Select(b => new BookShortDto
                {
                    BookId = b.BookId,
                    Title = b.Title
                }).ToList()
            }).ToList();

            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            var authorDto = new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = author.Books.Select(b => new BookShortDto
                {
                    BookId = b.BookId,
                    Title = b.Title
                }).ToList()
            };

            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> AddAuthor(CreateAuthorDto dto)
        {
            if (dto == null)
                return BadRequest();

            var newAuthor = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            await _authorRepo.AddAsync(newAuthor);

            var authorDto = new AuthorDto
            {
                Id = newAuthor.Id,
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName,
                Books = new List<BookShortDto>()
            };

            return CreatedAtAction(nameof(GetAuthorById), new { id = newAuthor.Id }, authorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, CreateAuthorDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;

            await _authorRepo.UpdateAsync(author);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            await _authorRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
