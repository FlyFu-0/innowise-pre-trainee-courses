namespace task_4_library_manger.Shared.DTOs;

public record BookDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public DateOnly? PublishedYear { get; init; }
    public Guid? AuthorId { get; init; }
}
