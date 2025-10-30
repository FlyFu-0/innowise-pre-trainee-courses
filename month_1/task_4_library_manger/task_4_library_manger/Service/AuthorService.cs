using AutoMapper;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Entities.Models;
using task_4_library_manger.Exceptions;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Service;

public sealed class AuthorService(IRepositoryManager repository, IMapper mapper) : IAuthorService
{
    public async Task<(IEnumerable<AuthorDto> authors, MetaData metaData)> GetAllAuthorsAsync(AuthorParameters authorParameters, bool trackChanges = false)
    {
        if (!authorParameters.ValidYearRange)
        {
            throw new InvalidYearRange();
        }

        var authorsWithMetaData = await repository.AuthorRepository.GetAuthorsAsync(authorParameters, trackChanges);
        var authorsMapped = mapper.Map<IEnumerable<AuthorDto>>(authorsWithMetaData);
        return (authorsMapped, authorsWithMetaData.MetaData);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid id, bool trackChanges = false)
    {
        var author = await repository.AuthorRepository.GetAuthorAsync(id, trackChanges);
        var authorMapped = mapper.Map<AuthorDto>(author);

        return authorMapped;
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorDtoForCreation author)
    {
        var authorCreated = mapper.Map<Author>(author);

        authorCreated.Id = Guid.NewGuid();
        repository.AuthorRepository.CreateAuthorAsync(authorCreated);
        await repository.SaveAsync();

        var authorMapped = mapper.Map<AuthorDto>(authorCreated);
        return authorMapped;
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        var author = await GetAuthorAndCheckIfExists(id);
        repository.AuthorRepository.DeleteAuthorAsync(author);
        await repository.SaveAsync();
    }

    private async Task<Author> GetAuthorAndCheckIfExists(Guid id, bool trackChanges = false)
    {
        var author = await repository.AuthorRepository.GetAuthorAsync(id, trackChanges);

        if (author is null)
        {
            throw new AuthorNotFoundException(id);
        }

        return author;
    }

    public async Task UpdateAuthorAsync(Guid id, AuthorDtoForUpdate authorForUpdate)
    {
        var author = await GetAuthorAndCheckIfExists(id);

        var authorUpdate = mapper.Map(authorForUpdate, author);
        repository.AuthorRepository.UpdateAuthorAsync(authorUpdate);
        await repository.SaveAsync();
    }
}
