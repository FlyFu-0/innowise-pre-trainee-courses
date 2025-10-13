using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using Dapper;
using Microsoft.Data.SqlClient;
using task_3_tasks_manager.Models;
using task_3_tasks_manager.Contracts;

namespace task_3_tasks_manager.Repositories;

public class Repository<T>(IDbConnectionFactory connectionFactory) : IRepository<T> 
    where T : BaseModel, new()
{
    protected readonly IDbConnectionFactory _connectionFactory = connectionFactory;
    
    public virtual string GetTableName()
    {
        return typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name;
    }
    
    public virtual List<string> GetProperties()
    {
        return typeof(T).GetProperties()
            .Where(p => p.GetCustomAttribute<FillableAttribute>() != null)
            .Select(p => p.Name)
            .ToList();
    }
    
    public virtual IEnumerable<T> GetAll()
    {
        using var db = _connectionFactory.CreateConnection();
        return db.Query<T>($"SELECT * FROM {GetTableName()}").ToList();
    }

    public virtual T Get(int id)
    {
        using var db = _connectionFactory.CreateConnection();

        var sqlQuery = $"SELECT * FROM {GetTableName()} WHERE Id = @id";
        return db.QueryFirstOrDefault<T>(sqlQuery, new { id });
    }

    public virtual void Add(T item)
    {
        using var db = _connectionFactory.CreateConnection();
        
        var fields = string.Join(", ", GetProperties());
        var valuesFields = string.Join(", ", GetProperties().Select(prop => $"@{prop}"));
        
        var sqlQuery =
            $"INSERT INTO {GetTableName()} ({fields}) VALUES ({valuesFields})";
        db.Execute(sqlQuery, item);
    }

    public virtual void Update(T item)
    {
        using var db = _connectionFactory.CreateConnection();
        
        var valuesFields = string.Join(", ", GetProperties().Select(prop => $"{prop} = @{prop}"));
        
        var sqlQuery =
            $"UPDATE {GetTableName()} " +
            $"SET {valuesFields} " +
            "WHERE Id = @Id";
        db.Execute(sqlQuery, item);
    }

    public virtual void Delete(int id)
    {
        using var db = _connectionFactory.CreateConnection();
        var sqlQuery = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
        db.Execute(sqlQuery, new { id });
    }
}