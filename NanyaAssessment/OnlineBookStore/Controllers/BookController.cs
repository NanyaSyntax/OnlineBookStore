using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Core.IService;
using OnlineBookStore.Data.DTO;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult<AddBookDTO>> AddBook(AddBookDTO bookDTO)
        {
            var addedBook = await _bookService.AddBookAsync(bookDTO);
            return CreatedAtAction(nameof(GetBookById), new { id = addedBook.BookId }, addedBook);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(string id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("search_Books")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBooks([FromQuery] string bookName)
        {
            var books = await _bookService.SearchBooksAsync(bookName);
            if (books == null || !books.Any())
            {
                return NotFound("No books found matching the search criteria.");
            }
            return Ok(books);
        }
    }
}
