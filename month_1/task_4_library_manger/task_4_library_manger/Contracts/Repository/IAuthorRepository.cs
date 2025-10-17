using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IAuthorRepository
{
    IEnumerable<Author> GetAuthors(bool trackChanges);
    Author? GetAuthor(int id, bool trackChanges);

    void UpdateAuthor(Author authorForUpdate);
    void CreateAuthor(Author author);

    void DeleteAuthor(Author author);
}
