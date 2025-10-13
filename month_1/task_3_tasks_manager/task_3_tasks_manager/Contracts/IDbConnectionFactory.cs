using System.Data;

namespace task_3_tasks_manager.Contracts;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}