using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Contracts.Service;

public interface IBookService
{
    Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBooksAsync(BookParameters bookParameters, bool trackChanges, Guid? authorId = null);
    Task<BookDto> GetBookAsync(Guid authorId, Guid id, bool trackChanges);
    Task<BookDto> CreateBookForAuthorAsync(Guid authorId, BookDtoForCreation bookForCreation);

    Task DeleteBookForAuthorAsync(Guid authorId, Guid id);

    Task UpdateBookForAuthorAsync(Guid authorId, Guid id, BookDtoForUpdate bookForUpdate);
}
