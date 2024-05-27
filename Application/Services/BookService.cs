using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
        var books = await bookRepository.GetBooksAsync();
        return mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await bookRepository.GetBookByIdAsync(id);
        return mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> CreateBookAsync(BookDto bookDto)
    {
        var book = mapper.Map<Book>(bookDto);
        await bookRepository.CreateBookAsync(book);
        return mapper.Map<BookDto>(book);
    }

    public async Task<bool> UpdateBookAsync(BookDto bookDto)
    {
        var book = mapper.Map<Book>(bookDto);
        return await bookRepository.UpdateBookAsync(book);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        return await bookRepository.DeleteBookAsync(id);
    }
}