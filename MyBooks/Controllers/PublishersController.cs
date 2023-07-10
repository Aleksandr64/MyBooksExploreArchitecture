using Application.CustomExceptions;
using Application.Services;
using Application.ViewModels;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Web.ActionResults;

namespace MyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                var newPublisher = _publisherServices.AddPublisher(publisher);
                return Created(nameof(AddNewPublisher), newPublisher);
            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllPublisher")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _result = _publisherServices.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpGet("GetPublisherById")]
        public CustomActionResult GetPublisherById(int id)
        {
            var _responce = _publisherServices.GetPublisherById(id);
            if(_responce != null)
            {
                var _responceObj = new CustomActionResultVM()
                {
                    Publisher = _responce,
                };

                return new CustomActionResult(_responceObj);
            }
            else
            {
                var _responceObj = new CustomActionResultVM()
                {
                    Exception = new Exception("This is comming from publishers controller")
                };

                return new CustomActionResult(_responceObj);
            }
        }

        [HttpGet("GetPublisherData")]
        public IActionResult GetPublisherData(int id) 
        {
            var _responce = _publisherServices.GetPublisherData(id);
            return Ok(_responce);
        }

        [HttpDelete("DeletePublisherById")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherServices.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
