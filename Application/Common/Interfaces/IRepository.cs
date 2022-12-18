using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Application.Common.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    T Add(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id, bool disableTracking = true);
    IQueryable<T> GetAll(bool disableTracking = true);
    IQueryable<T> GetAllByInc(string[] includeTables, bool disableTracking = true);
    IQueryable<T> GetAllByExp(Expression<Func<T, bool>> predicate, bool disableTracking = true);
    IQueryable<T> GetAllByExpInc(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
    IQueryable<T> GetAllByExpOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
    IQueryable<T> GetAllByExpIncOrder(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
    IQueryable<T> GetAllByOrderPage(int page, int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
    IQueryable<T> GetAllByExpOrderPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
    IQueryable<T> GetAllByIncPage(int page, int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
    IQueryable<T> GetAllByExpIncPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);
    Task<int> GetCountAsync(bool disableTracking = true);
    Task<int> GetCountExpAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true);
}
