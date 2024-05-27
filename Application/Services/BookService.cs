using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
        var books = await bookRepository.GetBooksAsync();
        return mapper.Map<IEnumerable<BookDto>>(books);
    }
}