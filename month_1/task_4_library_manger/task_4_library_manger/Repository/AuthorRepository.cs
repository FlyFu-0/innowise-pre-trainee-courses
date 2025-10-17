using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class AuthorRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Author>(repositoryContext.Authors), IAuthorRepository
{
    public IEnumerable<Author> GetAuthors(bool trackChanges)
        => FindAll(trackChanges).ToList();

    public Author? GetAuthor(int id, bool trackChanges)
        => FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();

    public void UpdateAuthor(Author authorForUpdate)
        => Update(authorForUpdate);

    public void CreateAuthor(Author author)
        => Create(author);

    public void DeleteAuthor(Author author)
        => Delete(author);
}
