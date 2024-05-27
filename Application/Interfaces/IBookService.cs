using Application.DTOs;

namespace Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
}