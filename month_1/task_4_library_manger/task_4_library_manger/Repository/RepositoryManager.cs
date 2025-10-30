using task_4_library_manger.Contracts.Repository;

namespace task_4_library_manger.Repository;

public sealed class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
{
    private readonly Lazy<IAuthorRepository> _authorRepository = new(() => new AuthorRepository(repositoryContext));
    private readonly Lazy<IBookRepository> _bookRepository = new(() => new BookRepository(repositoryContext));

    public IAuthorRepository AuthorRepository => _authorRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;

    public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
}
