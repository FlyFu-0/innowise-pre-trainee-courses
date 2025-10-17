using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks(bool trackChanges);
    Book GetBook(int id, bool trackChanges);

    void CreateBook(Book book);

    void DeleteBook(Book book);
}