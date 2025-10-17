using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Models;

namespace task_4_library_manger.Service;

public sealed class AuthorService(IRepositoryManager repository) : IAuthorService
{
    public IEnumerable<Author> GetAllAuthors(bool trackChanges)
    {
        return repository.AuthorRepository.GetAuthors(trackChanges);
    }

    public Author GetAuthor(int id, bool trackChanges)
    {
        return repository.AuthorRepository.GetAuthor(id, trackChanges);
    }

    public Author CreateAuthor(Author author)
    {
        repository.AuthorRepository.CreateAuthor(author);
        return author;
    }

    public IEnumerable<Author> GetByIds(IEnumerable<int> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public (IEnumerable<Author> authors, string ids) CreateAuthorCollection(IEnumerable<Author> authors)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(int id, bool trackChanges)
    {
        var author = repository.AuthorRepository.GetAuthor(id, trackChanges);

        if (author is null)
        {
            throw new Exception($"Author with {id} not found");
        }
        repository.AuthorRepository.DeleteAuthor(author);
    }

    public void UpdateAuthor(int id, Author authorForUpdate, bool trackChanges)
    {
        var author = repository.AuthorRepository.GetAuthor(id, trackChanges);

        if (author is null)
        {
            throw new Exception($"Author with {id} not found");
        }
        repository.AuthorRepository.UpdateAuthor(authorForUpdate);
    }
}
