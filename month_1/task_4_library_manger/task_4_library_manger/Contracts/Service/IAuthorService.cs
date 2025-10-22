using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Contracts.Service;

public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAllAuthors();

    AuthorDto GetAuthor(Guid id);

    AuthorDto CreateAuthor(AuthorDtoForCreation author);

    void DeleteAuthor(Guid id);

    AuthorDto UpdateAuthor(Guid id, AuthorDtoForUpdate authorForUpdate);
}
