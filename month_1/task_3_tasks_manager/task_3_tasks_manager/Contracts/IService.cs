using task_3_tasks_manager.Models;

namespace task_3_tasks_manager.Contracts;

public interface IService<T> where T : BaseModel, new()
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> Get(int id);
    public Task<bool> Add(T item);
    public Task<bool> Update(T item);
    public Task<bool> Delete(int id);
}
