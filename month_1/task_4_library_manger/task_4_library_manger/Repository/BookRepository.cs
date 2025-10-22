using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class BookRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Book>(repositoryContext.Books), IBookRepository
{
    public IEnumerable<Book> GetBooks()
        => FindAll().ToList();

    public IEnumerable<Book> GetBooksForAuthor(Guid authorId)
        => FindByCondition(b => b.AuthorId.Equals(authorId)).ToList();

    public Book GetBook(Guid authorId, Guid id)
        => FindByCondition(b => b.Id.Equals(id) && b.AuthorId.Equals(authorId)).SingleOrDefault();

    public void CreateBook(Book book)
        => Create(book);

    public void UpdateBook(Book book)
        => Update(book);

    public void DeleteBook(Book book)
        => Delete(book);
}
