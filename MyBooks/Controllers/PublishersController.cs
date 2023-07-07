using Application.Services;
using Application.ViewModels;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Web.Controllers
{
    public class PublishersController : Controller
    {
        private PublishersService _publisherServices;

        public PublishersController(PublishersService publisherServices)
        {
            _publisherServices = publisherServices;
        }

        [HttpPost("AddNewPublisher")]
        public IActionResult AddNewPublisher([FromBody] PublisherVm publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("GetPublisherBooksAndAuthorsById")]
        public IActionResult GetPublisherData(int id) 
        {
            var _responce = _publisherServices.GetPublisherData(id);
            return Ok(_responce);
        }

        [HttpDelete("DeletePublisher")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherServices.DeletePublisherById(id);
            return Ok();
        }

    }
}
