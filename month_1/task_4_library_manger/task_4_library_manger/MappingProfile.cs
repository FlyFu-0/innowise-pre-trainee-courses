using AutoMapper;
using task_4_library_manger.Entities.Models;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDtoForCreation, Author>();
        CreateMap<AuthorDtoForUpdate, Author>();

        CreateMap<Book, BookDto>();
        CreateMap<BookDtoForCreation, Book>();
        CreateMap<BookDtoForUpdate, Book>();
    }
}
