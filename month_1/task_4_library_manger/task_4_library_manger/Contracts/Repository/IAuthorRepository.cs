using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync(bool trackChanges);
    Task<Author> GetAuthorAsync(int id, bool trackChanges);

    void CreateAuthor(Author author);

    void DeleteAuthor(Author author);
}