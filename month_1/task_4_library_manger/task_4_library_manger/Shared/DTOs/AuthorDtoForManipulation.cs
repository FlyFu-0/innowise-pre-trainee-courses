using System.ComponentModel.DataAnnotations;

namespace task_4_library_manger.Shared.DTOs;

public record AuthorDtoForManipulation
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Date of birthday is required")]
    public DateTime? DateOfBirth { get; init; }

    public IEnumerable<BookDtoForCreation>? Books { get; init; }
}
