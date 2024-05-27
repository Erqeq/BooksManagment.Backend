using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(BooksContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }
}