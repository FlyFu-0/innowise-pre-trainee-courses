namespace task_4_library_manger.Shared.DTOs;

public record AuthorDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public DateTime? DateOfBirth { get; init; }
}
