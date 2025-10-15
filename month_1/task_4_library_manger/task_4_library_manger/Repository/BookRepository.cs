using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class BookRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Book>(repositoryContext), IBookRepository
{
    public Task<IEnumerable<Book>> GetBooksAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookAsync(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }
}