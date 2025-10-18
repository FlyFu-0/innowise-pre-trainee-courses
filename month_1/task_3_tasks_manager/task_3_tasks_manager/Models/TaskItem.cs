using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_3_tasks_manager.Models;

[Table("Tasks")]
public class TaskItem : BaseModel
{

    [Fillable]
    [Required(ErrorMessage = "Title is required")]
    [MinLength(1, ErrorMessage = "Title must not be empty")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Fillable]
    [Required(ErrorMessage = "Description is required")]
    [MinLength(1, ErrorMessage = "Description must not be empty")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Fillable]
    public bool IsCompleted { get; set; } = false;
}
