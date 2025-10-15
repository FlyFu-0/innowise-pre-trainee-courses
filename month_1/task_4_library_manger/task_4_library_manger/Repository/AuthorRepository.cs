using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class AuthorRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Author>(repositoryContext), IAuthorRepository
{
    public Task<IEnumerable<Author>> GetAuthorsAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetAuthorAsync(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Author author)
    {
        throw new NotImplementedException();
    }
}