using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Contracts.Service;

public interface IAuthorService
{
    Task<(IEnumerable<AuthorDto> authors, MetaData metaData)> GetAllAuthorsAsync(AuthorParameters authorParameters,bool trackChanges);

    Task<AuthorDto> GetAuthorAsync(Guid id, bool trackChanges);

    Task<AuthorDto> CreateAuthorAsync(AuthorDtoForCreation author);

    Task DeleteAuthorAsync(Guid id);

    Task UpdateAuthorAsync(Guid id, AuthorDtoForUpdate authorForUpdate);
}
