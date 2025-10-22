using System.ComponentModel.DataAnnotations;

namespace task_4_library_manger.Shared.DTOs;

public record BookDtoForManipulation
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string? Title { get; init; }

    [Required(ErrorMessage = "Published Year is required")]
    public DateOnly? PublishedYear { get; init; }

    [Required(ErrorMessage = "Author is required")]
    public Guid? AuthorId { get; set; }
}
