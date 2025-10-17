using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class BookRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Book>(repositoryContext.Books), IBookRepository
{
    public IEnumerable<Book> GetBooks(bool trackChanges)
        => FindAll(trackChanges).ToList().AsReadOnly();

    public Book GetBook(int id, bool trackChanges)
        => FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();

    public void CreateBook(Book book)
        => Create(book);

    public void DeleteBook(Book book)
        => Delete(book);
}
