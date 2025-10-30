using task_4_library_manger.Models;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Contracts.Repository;

public interface IBookRepository
{
    Task<PagedList<Book>> GetBooksAsync(BookParameters booksParameters, bool trackChanges, Guid? authorId = null);
    Task<Book> GetBookAsync(Guid authorId, Guid id, bool trackChanges);

    void CreateBookAsync(Book book);

    void UpdateBookAsync(Book book);

    void DeleteBookAsync(Book book);
}
