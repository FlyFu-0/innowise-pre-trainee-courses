using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Repository;

public interface IAuthorRepository
{
    IEnumerable<Author> GetAuthors();
    Author GetAuthor(Guid id);

    void UpdateAuthor(Author author);
    void CreateAuthor(Author author);

    void DeleteAuthor(Author author);
}
