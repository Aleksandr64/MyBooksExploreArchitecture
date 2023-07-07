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

        [HttpPost("AddPublisher")]
        public IActionResult AddNewPublisher([FromBody] PublisherVm publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-books-with-authore-by-id")]
        public IActionResult GetPublisherData(int publisherId) 
        {
            var _responce = _publisherServices.GetPublisherData(publisherId);
            return Ok(_responce);
        }
    }
}
