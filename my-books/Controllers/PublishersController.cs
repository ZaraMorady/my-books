using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        public PublishersService _publisherService;

        public PublishersController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM author)
        {
            _publisherService.AddPublisher(author);
            return Ok();
        }

        [HttpGet("get-publisher-with-books-and-authors-by-id/{id}")]

        public IActionResult GetPublisherWithBooksAndAuthors(int id)
        {
            var response = _publisherService.GetPublisherData(id);
            return Ok(response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]

        public IActionResult DelPublisherById(int id)
        {
            _publisherService.DeletePublisherById(id);
            return Ok();
           
        }


    }
}
