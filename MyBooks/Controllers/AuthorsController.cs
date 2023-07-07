using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVm author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("AuthorAndBooks")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var responce = _authorService.GetAuthorWithBooks(id);
            return Ok(responce);
        }
    }
}
