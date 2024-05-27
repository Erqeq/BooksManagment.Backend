using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
    {
        var createdBook = await _bookService.CreateBookAsync(bookDto);
        return CreatedAtAction(nameof(GetBookById),
            new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
    {
        if (id != bookDto.Id)
        {
            return BadRequest();
        }

        var result = await _bookService.UpdateBookAsync(bookDto);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}