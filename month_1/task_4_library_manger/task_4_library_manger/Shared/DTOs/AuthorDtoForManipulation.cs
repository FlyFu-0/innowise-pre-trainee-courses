namespace task_4_library_manger.Shared.DTOs;

public record AuthorDtoForManipulation
{
    public string? Name { get; init; }
    public DateTime? DateOfBirth { get; init; }
}
