using task_4_library_manger.Entities.Models;

namespace task_4_library_manger.Models;

public class Book : BaseModel
{
    public string? Title { get; set; }
    public DateOnly? PublishedYear { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}
