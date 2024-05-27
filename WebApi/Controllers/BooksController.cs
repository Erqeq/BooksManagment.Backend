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

    /// <summary>
    /// Get all books   
    /// </summary>
    /// <returns>List of books</returns>
    [HttpGet(Name = "GetAllBooks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    /// <summary>
    /// Get a book by id
    /// </summary>
    /// <param name="id">Book id</param>
    /// <returns>Book detail</returns>
    [HttpGet("{id}", Name = "GetBookById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    /// <summary>
    /// Create a new book
    /// </summary>
    /// <param name="bookDto">Book data</param>
    /// <returns>Created book</returns>
    [HttpPost(Name = "CreateBook")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
    {
        var createdBook = await _bookService.CreateBookAsync(bookDto);

        return CreatedAtAction(nameof(GetBookById),
            new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}", Name = "UpdateBook")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    /// <summary>
    /// Delete a book by id.
    /// </summary>
    /// <param name="id">Book Id</param>
    [HttpDelete("{id}", Name = "DeleteBook")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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