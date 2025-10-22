using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Contracts.Service;

public interface IBookService
{
    IEnumerable<BookDto> GetBooks();
    IEnumerable<BookDto> GetBooksForAuthor(Guid authorId);
    BookDto GetBook(Guid authorId, Guid id);
    BookDto CreateBookForAuthor(Guid authorId, BookDtoForCreation bookForCreation);

    void DeleteBookForAuthor(Guid authorId, Guid id);

    BookDto UpdateBookForAuthor(Guid authorId, Guid id, BookDtoForUpdate bookForUpdate);
}
