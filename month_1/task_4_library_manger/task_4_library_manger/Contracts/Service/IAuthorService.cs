using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Service;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);

    Task<Author> GetAuthorAsync(int id, bool trackChanges);

    Task<Author> CreateAuthorAsync(Author author);

    Task<IEnumerable<Author>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);

    Task<(IEnumerable<Author> authors, string ids)> CreateAuthorCollectionAsync(IEnumerable<Author> authors);

    Task DeleteAuthorAsync(int id, bool trackChanges);

    Task UpdateAuthorAsync(int id, Author author, bool trackChanges);
}