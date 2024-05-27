using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksContext _context;

    public BookRepository(BooksContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }
}