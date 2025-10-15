using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Models;

namespace task_4_library_manger.Service;

public class BookService: IBookService
{
    private readonly IRepositoryManager _repository;
    
    public BookService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Book>> GetBooksAsync(int authorId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookAsync(int authorId, int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Book> CreateBookForCompanyAsync(int authorId, Book bookForCreation, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookForCompanyAsync(int authorId, int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookForCompanyAsync(int authorId, int id, Book bookForUpdate, bool authorTrackChanges,
        bool bookTrackChanges)
    {
        throw new NotImplementedException();
    }
}