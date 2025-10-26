using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Contracts.Service;

public interface IAuthorService
{
    IEnumerable<AuthorDto> GetAllAuthors();

    AuthorDto GetAuthor(Guid id);

    AuthorDto CreateAuthor(AuthorDtoForCreation author);

    void DeleteAuthor(Guid id);

    void UpdateAuthor(Guid id, AuthorDtoForUpdate authorForUpdate);
}
