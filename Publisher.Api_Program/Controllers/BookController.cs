using Microsoft.AspNetCore.Mvc;
using Publisher.Domain.Dtos;
using Publisher.Domain.Models;
using Publisher.Domain.Repositories;

namespace Publisher.Api_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await _bookRepo.GetAllAsync();

            var bookDtos = books.Select(book => new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                PublishDate = book.PublishDate,
                BasePrice = book.BasePrice,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : null,
                CoverId = book.Cover?.CoverId,
                CoverTitle = book.Cover?.Title
            }).ToList();

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            var bookDto = new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                PublishDate = book.PublishDate,
                BasePrice = book.BasePrice,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : null,
                CoverId = book.Cover?.CoverId,
                CoverTitle = book.Cover?.Title
            };

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(CreateBookDto dto)
        {
            if (dto == null)
                return BadRequest();

            var newBook = new Book
            {
                Title = dto.Title,
                PublishDate = dto.PublishDate,
                BasePrice = dto.BasePrice,
                AuthorId = dto.AuthorId,
            };

            await _bookRepo.AddAsync(newBook);

            var bookDto = new BookDto
            {
                BookId = newBook.BookId,
                Title = newBook.Title,
                PublishDate = newBook.PublishDate,
                BasePrice = newBook.BasePrice,
                AuthorId = newBook.AuthorId,
                AuthorName = null,
                CoverId = null,
                CoverTitle = null
            };

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.BookId }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            book.Title = dto.Title;
            book.PublishDate = dto.PublishDate;
            book.BasePrice = dto.BasePrice;
            book.AuthorId = dto.AuthorId;

            await _bookRepo.UpdateAsync(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
         //   if (book.BookId == 1)
         //       return bookid;
            if (book == null)
                return NotFound();

            await _bookRepo.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("ByAuthor/{authorId}")]
        public async Task<ActionResult<List<BookDto>>> GetBooksByAuthor(int authorId)
        {
            var books = await _bookRepo.GetAllAsync();
            var filteredBooks = books.Where(b => b.AuthorId == authorId).ToList();

            var bookDtos = filteredBooks.Select(book => new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                PublishDate = book.PublishDate,
                BasePrice = book.BasePrice,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : null,
                CoverId = book.Cover?.CoverId,
                CoverTitle = book.Cover?.Title
            }).ToList();

            return Ok(bookDtos);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<BookDto>>> SearchBooks([FromQuery] string title)
        {
            var books = await _bookRepo.GetAllAsync();
            var filteredBooks = books
                .Where(b => b.Title != null && b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var bookDtos = filteredBooks.Select(book => new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                PublishDate = book.PublishDate,
                BasePrice = book.BasePrice,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : null,
                CoverId = book.Cover?.CoverId,
                CoverTitle = book.Cover?.Title
            }).ToList();

            return Ok(bookDtos);
        }


    }
}
