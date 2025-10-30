using Microsoft.EntityFrameworkCore;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;
using task_4_library_manger.Repository.Extensions;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Repository;

public class BookRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Book>(repositoryContext), IBookRepository
{
    public async Task<PagedList<Book>> GetBooksAsync(BookParameters booksParameters, bool trackChanges, Guid? authorId = null)
    {
        var query = authorId is null
            ? FindAll(trackChanges)
            : FindByCondition(b => b.AuthorId.Equals(authorId), trackChanges);

        var books = await query
            .FilterBooks(booksParameters.MinPublishYear, booksParameters.MaxPublishYear)
            .Search(booksParameters.SearchTerm)
            .ToListAsync();

        return PagedList<Book>.ToPagedList(books, booksParameters.PageNumber, booksParameters.PageSize);
    }

    public async Task<Book> GetBookAsync(Guid authorId, Guid id, bool trackChanges)
        => await FindByCondition(b => b.Id.Equals(id) && b.AuthorId.Equals(authorId), trackChanges).SingleOrDefaultAsync();

    public void CreateBookAsync(Book book)
        => Create(book);

    public void UpdateBookAsync(Book book)
        => Update(book);

    public void DeleteBookAsync(Book book)
        => Delete(book);
}
