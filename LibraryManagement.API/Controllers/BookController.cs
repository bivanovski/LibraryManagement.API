using LibraryManagement.Service.DTOs;
using LibraryManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.getAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _bookService.getBookByIdAsync(id);
            return result == null ? NotFound("Book not found.") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDTO dto)
        {
            var result = await _bookService.createBookAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDTO dto)
        {
            var result = await _bookService.UpdateBookAsync(id, dto);
            return result == null ? NotFound("Book not found.") : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            return success ? NoContent() : NotFound("Book not found.");
        }
    }
}
