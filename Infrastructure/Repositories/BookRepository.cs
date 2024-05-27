using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task CreateBookAsync(Book book)
    {
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
    }

    public async Task<bool> UpdateBookAsync(Book book)
    {
        context.Books.Update(book);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return false;
        }

        context.Books.Remove(book);
        return await context.SaveChangesAsync() > 0;
    }
}