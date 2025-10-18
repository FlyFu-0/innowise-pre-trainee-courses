using task_3_tasks_manager.Contracts;
using task_3_tasks_manager.Models;

namespace task_3_tasks_manager.Services;

public class TaskService(IRepository<TaskItem> repository) : Service<TaskItem>(repository)
{
 //
}
