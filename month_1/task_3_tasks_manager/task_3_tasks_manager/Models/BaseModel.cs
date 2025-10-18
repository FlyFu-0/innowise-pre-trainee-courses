namespace task_3_tasks_manager.Models;

public abstract class BaseModel
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
}
