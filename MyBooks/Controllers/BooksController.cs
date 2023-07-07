﻿using Application.Services;
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

        [HttpGet("GetAllBook")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBooks();
            return Ok(allbooks);
        }
        [HttpGet("GetIdBook")]
        public IActionResult GetIdBooks(int bookid)
        {
            var book = _booksService.GetBookById(bookid);
            return Ok(book);
        }

        [HttpPost("AddNewBook")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("UpdateBook")]
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
