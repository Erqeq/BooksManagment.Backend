using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
}