using System.Data;
using Microsoft.Data.SqlClient;
using task_3_tasks_manager.Contracts;

namespace task_3_tasks_manager.Repositories;

public class SqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    private readonly string _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}