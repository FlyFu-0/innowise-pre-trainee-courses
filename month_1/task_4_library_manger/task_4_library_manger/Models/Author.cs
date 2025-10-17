namespace task_4_library_manger.Models;

public class Author : BaseModel
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}