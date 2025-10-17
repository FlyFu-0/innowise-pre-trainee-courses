using task_4_library_manger.Models;

namespace task_4_library_manger.Contracts.Service;

public interface IAuthorService
{
    IEnumerable<Author> GetAllAuthors(bool trackChanges);

    Author GetAuthor(int id, bool trackChanges);

    Author CreateAuthor(Author author);

    IEnumerable<Author> GetByIds(IEnumerable<int> ids, bool trackChanges);

    (IEnumerable<Author> authors, string ids) CreateAuthorCollection(IEnumerable<Author> authors);

    void DeleteAuthor(int id, bool trackChanges);

    void UpdateAuthor(int id, Author authorForUpdate, bool trackChanges);
}
