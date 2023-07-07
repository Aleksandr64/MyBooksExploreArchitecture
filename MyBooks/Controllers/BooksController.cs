using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksServices _booksService;
        public BooksController(BooksServices booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBooks();
            return Ok(allbooks);
        }
        [HttpGet("GetIDBooks")]
        public IActionResult GetIdBooks(int bookid)
        {
            var book = _booksService.GetBookById(bookid);
            return Ok(book);
        }

        [HttpPost("add-new-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("update-book-by-id")]
        public IActionResult UpdateBookId(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBookById(int bookId) 
        {
            _booksService.DeleteBook(bookId);
            return Ok();
        }
    }
}
