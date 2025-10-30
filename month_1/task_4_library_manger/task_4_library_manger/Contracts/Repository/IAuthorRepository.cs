using task_4_library_manger.Entities.Models;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Contracts.Repository;

public interface IAuthorRepository
{
    Task<PagedList<Author>> GetAuthorsAsync(AuthorParameters authorParameters, bool trackChanges);
    Task<Author> GetAuthorAsync(Guid id, bool trackChanges);

    void UpdateAuthorAsync(Author author);
    void CreateAuthorAsync(Author author);

    void DeleteAuthorAsync(Author author);
}
