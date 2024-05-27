using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task CreateBookAsync(Book book);
    Task<bool> UpdateBookAsync(Book book);
    Task<bool> DeleteBookAsync(int id);
}