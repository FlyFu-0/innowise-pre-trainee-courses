using System.Linq.Expressions;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Models;

namespace task_4_library_manger.Repository;

public class RepositoryBase<T>(List<T> collection) : IRepositoryBase<T>
    where T : BaseModel
{
    protected readonly List<T> _collection = collection;

    public IQueryable<T> FindAll(bool trackingChanges)
        => _collection.AsQueryable();

    public IQueryable<T> FindByCondition(Func<T, bool> expression, bool trackChanges)
        => _collection.Where(expression).AsQueryable();

    public void Create(T entity)
    {
        if (entity.Id == 0)
        {
            var maxId = _collection.Count != 0 ? _collection.Max(b => b.Id) : 0;
            entity.Id = maxId + 1;
        }

        _collection.Add(entity);
    }

    public void Update(T entity)
    {
        var index = _collection.FindIndex(e => e.Equals(entity));
        if (index != -1)
            _collection[index] = entity;
    }

    public void Delete(T entity)
        => _collection.Remove(entity);
}
