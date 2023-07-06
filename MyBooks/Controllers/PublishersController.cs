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
    }
}
