using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class AuthorRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Author>(repositoryContext.Authors), IAuthorRepository
{
    public IEnumerable<Author> GetAuthors()
        => FindAll().ToList();

    public Author GetAuthor(Guid id)
        => FindByCondition(b => b.Id.Equals(id)).SingleOrDefault();

    public void UpdateAuthor(Author author)
        => Update(author);

    public void CreateAuthor(Author author)
        => Create(author);

    public void DeleteAuthor(Author author)
        => Delete(author);
}
