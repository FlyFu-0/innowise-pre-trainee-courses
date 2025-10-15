using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Service;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync(int authorId, bool trackChanges);
    Task<Book> GetBookAsync(int authorId, int id, bool trackChanges);
    Task<Book> CreateBookForCompanyAsync(int authorId, Book bookForCreation, bool trackChanges);

    Task DeleteBookForCompanyAsync(int authorId, int id, bool trackChanges);

    Task UpdateBookForCompanyAsync(int authorId, int id, Book bookForUpdate,
        bool authorTrackChanges, bool bookTrackChanges);
}