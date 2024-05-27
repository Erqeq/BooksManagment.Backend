using Application.DTOs;

namespace Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto> GetBookByIdAsync(int id);
    Task<BookDto> CreateBookAsync(BookDto bookDto);
    Task<bool> UpdateBookAsync(BookDto bookDto);
    Task<bool> DeleteBookAsync(int id);
}