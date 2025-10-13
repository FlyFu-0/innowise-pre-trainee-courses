using task_3_tasks_manager.Contracts;
using task_3_tasks_manager.Models;

namespace task_3_tasks_manager.Repositories;

public class TasksRepository(IDbConnectionFactory connectionFactory) : Repository<TaskItem>(connectionFactory)
{
    //
}