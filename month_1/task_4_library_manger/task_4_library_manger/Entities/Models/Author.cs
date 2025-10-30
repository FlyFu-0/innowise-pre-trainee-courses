using task_4_library_manger.Models;

namespace task_4_library_manger.Entities.Models;

public class Author : BaseModel
{
    public string? Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public ICollection<Book> Books { get; set; }
}
