using task_4_library_manger.Contracts.Repository;

namespace task_4_library_manger.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IBookRepository> _bookRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
        
        // _repositoryContext.SeedData();
    }

    public IAuthorRepository AuthorRepository => _authorRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;
    
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
