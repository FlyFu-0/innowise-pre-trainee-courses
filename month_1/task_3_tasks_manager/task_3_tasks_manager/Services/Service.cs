using task_3_tasks_manager.Contracts;
using task_3_tasks_manager.Models;
using task_3_tasks_manager.Repositories;

namespace task_3_tasks_manager.Services;

public class Service<T>(IRepository<T> repository): IService<T> where T : BaseModel, new()
{
    public async Task<IEnumerable<T>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<T> Get(int id)
    {
        return await GetEntityAndCheckIfExists(id);
    }

    protected async Task<T> GetEntityAndCheckIfExists(int id)
    {
        var entity = await repository.Get(id);
        if (entity is null)
        {
            throw new Exception("Entity not found!");
        }

        return entity;
    }

    public async Task<bool> Add(T item)
    {
        return await repository.Add(item);
    }

    public async Task<bool> Update(T item)
    {
        await GetEntityAndCheckIfExists(item.Id);
        return await repository.Update(item);
    }

    public async Task<bool> Delete(int id)
    {
        var entity = GetEntityAndCheckIfExists(id);
        return await repository.Delete(entity.Id);
    }
}
