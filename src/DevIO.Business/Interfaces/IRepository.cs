using DevIO.Business.Models;
using System.Linq.Expressions;

namespace DevIO.Business.Interfaces;

public interface IRepository<T> : IDisposable where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<int> SaveChangesAsync();
}
