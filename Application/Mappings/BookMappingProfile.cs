using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
    }
}