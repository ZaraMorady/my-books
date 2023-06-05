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
    public class BooksController : ControllerBase
    {

        public BooksService _bookService;
        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id) { 
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBookWithAU(book);
            return Ok();
         }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpateBookById(int id, [FromBody] BookVM book)
        {
            var updBook = _bookService.updateBookById(id,book);
            return Ok(updBook);
        }

        [HttpDelete]

        public IActionResult delBookById(int id)
        {
            _bookService.DelBookById(id);
            return Ok();

        }

    }
}
