namespace task_4_library_manger.Models;

public class Book : BaseModel
{
    public string? Title { get; set; }
    public DateTime? PublishedYear { get; set; }
    public int? AuthorId { get; set; }
}