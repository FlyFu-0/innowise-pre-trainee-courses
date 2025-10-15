namespace task_4_library_manger.Contracts.Repository;

public interface IRepositoryManager
{
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }

    Task SaveAsync();
}