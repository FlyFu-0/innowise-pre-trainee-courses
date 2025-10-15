using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Models;

namespace task_4_library_manger.Service;

public sealed class AuthorService: IAuthorService
{
    private readonly IRepositoryManager _repository;
    public AuthorService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetAuthorAsync(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Author> CreateAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<(IEnumerable<Author> authors, string ids)> CreateAuthorCollectionAsync(IEnumerable<Author> authors)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAuthorAsync(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAuthorAsync(int id, Author author, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}