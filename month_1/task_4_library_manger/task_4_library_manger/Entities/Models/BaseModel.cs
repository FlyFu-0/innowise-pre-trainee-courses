namespace task_4_library_manger.Models;

public abstract class BaseModel
{
    public Guid Id { get; set; } = Guid.Empty;
}
