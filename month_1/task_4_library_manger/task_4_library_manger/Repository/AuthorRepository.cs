using Microsoft.EntityFrameworkCore;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Entities.Models;
using task_4_library_manger.Repository.Extensions;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Repository;

public class AuthorRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Author>(repositoryContext), IAuthorRepository
{
    public async Task<PagedList<Author>> GetAuthorsAsync(AuthorParameters authorParameters, bool trackChanges)
    {
        var authors = await FindAll(trackChanges)
            .FilterAuthors(authorParameters.MinDateOfBirthday, authorParameters.MaxDateOfBirthday)
            .Search(authorParameters.SearchTerm)
            .Include(author => author.Books)
            .ToListAsync();

        return PagedList<Author>.ToPagedList(authors,
            authorParameters.PageNumber, authorParameters.PageSize);
    }

    public async Task<Author> GetAuthorAsync(Guid id, bool trackChanges)
        => await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .Include(author => author.Books)
            .SingleOrDefaultAsync();

    public void UpdateAuthorAsync(Author author)
        => Update(author);

    public void CreateAuthorAsync(Author author)
        => Create(author);

    public void DeleteAuthorAsync(Author author)
        => Delete(author);
}
