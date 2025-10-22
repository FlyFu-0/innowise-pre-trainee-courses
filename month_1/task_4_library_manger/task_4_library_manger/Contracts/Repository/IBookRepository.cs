using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks();
    IEnumerable<Book> GetBooksForAuthor(Guid authorId);
    Book GetBook(Guid authorId, Guid id);

    void CreateBook(Book book);

    void UpdateBook(Book book);

    void DeleteBook(Book book);
}
