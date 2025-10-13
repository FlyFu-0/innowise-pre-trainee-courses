using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using task_3_tasks_manager.Models;

namespace task_3_tasks_manager.Contracts;

public interface IRepository<T> where T : BaseModel, new()
{
    public string GetTableName();

    public List<string> GetProperties();
    
    public IEnumerable<T> GetAll();
    public T Get(int id);
    public void Add(T item);
    public void Update(T item);
    public void Delete(int id);
}