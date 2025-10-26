using AutoMapper;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Exceptions;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Service;

public sealed class AuthorService(IRepositoryManager repository, IMapper mapper) : IAuthorService
{
    public IEnumerable<AuthorDto> GetAllAuthors()
    {
        var authors = repository.AuthorRepository.GetAuthors();
        var authorsMapped = mapper.Map<IEnumerable<AuthorDto>>(authors);
        return authorsMapped;
    }

    public AuthorDto GetAuthor(Guid id)
    {
        var author = repository.AuthorRepository.GetAuthor(id);
        var authorMapped = mapper.Map<AuthorDto>(author);

        return authorMapped;
    }

    public AuthorDto CreateAuthor(AuthorDtoForCreation author)
    {
        var authorCreated = mapper.Map<Author>(author);

        authorCreated.Id = Guid.NewGuid();
        repository.AuthorRepository.CreateAuthor(authorCreated);

        var authorMapped = mapper.Map<AuthorDto>(authorCreated);
        return authorMapped;
    }

    public void DeleteAuthor(Guid id)
    {
        var author = GetAuthorAndCheckIfExists(id);
        repository.AuthorRepository.DeleteAuthor(author);
    }

    private Author GetAuthorAndCheckIfExists(Guid id)
    {
        var author = repository.AuthorRepository.GetAuthor(id);

        if (author is null)
        {
            throw new AuthorNotFoundException(id);
        }

        return author;
    }

    public void UpdateAuthor(Guid id, AuthorDtoForUpdate authorForUpdate)
    {
        var author = GetAuthorAndCheckIfExists(id);

        var authorUpdate = mapper.Map(authorForUpdate, author);
        repository.AuthorRepository.UpdateAuthor(authorUpdate);
    }
}
