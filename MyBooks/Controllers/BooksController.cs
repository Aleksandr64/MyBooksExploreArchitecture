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

        [HttpPost("AddNewBook")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }
    }
}
