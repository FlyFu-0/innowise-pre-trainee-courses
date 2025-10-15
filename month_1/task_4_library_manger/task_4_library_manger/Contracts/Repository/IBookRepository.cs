using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync(bool trackChanges);
    Task<Book> GetBookAsync(int id, bool trackChanges);

    void CreateBook(Book book);

    void DeleteBook(Book book);
}