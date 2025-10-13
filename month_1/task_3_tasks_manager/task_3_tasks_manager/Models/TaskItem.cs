using System.ComponentModel.DataAnnotations.Schema;

namespace task_3_tasks_manager.Models;

[Table("Tasks")]
public class TaskItem : BaseModel
{
    
    [Fillable]
    public string Title { get; set; }
    
    [Fillable]
    public string Description { get; set; }
    
    [Fillable]
    public bool IsCompleted { get; set; }
}