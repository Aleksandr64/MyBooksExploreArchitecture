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

        [HttpPost("add-publisher")]
        public IActionResult AddNewPublisher([FromBody] PublisherVm publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-books-with-authore-by-id")]
        public IActionResult GetPublisherData(int id) 
        {
            var _responce = _publisherServices.GetPublisherData(id);
            return Ok(_responce);
        }

        [HttpDelete("delete-publisher-by-id")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherServices.DeletePublisherById(id);
            return Ok();
        }

    }
}
