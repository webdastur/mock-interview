using Application.Common.Interfaces;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext context;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public T Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
        return entity;
    }

    public void UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public async Task<T> GetByIdAsync(int id, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query.AsNoTracking();
        }

        return await query.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public IQueryable<T> GetAllByExpIncPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        query = orderBy(query);
        query = query.Where(predicate);

        foreach (var table in includeTables)
        {
            query = query.Include(table);
        }

        if (page > 1) query = query.Skip((page - 1) * limit);

        query = query.Take(limit);

        return query;
    }

    public Task<int> GetCountAsync(bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        return query.CountAsync();
    }

    public Task<int> GetCountExpAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        return query.Where(predicate).CountAsync();
    }

    public IQueryable<T> GetAllByExpOrderPage(int page, int limit, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        query = orderBy(query);
        query = query.Where(predicate);

        if (page > 1) query = query.Skip((page - 1) * limit);

        query = query.Take(limit);

        return query;
    }

    public IQueryable<T> GetAllByIncPage(int page, int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        foreach (var table in includeTables)
        {
            query = query.Include(table);
        }

        query = orderBy(query);
        if (page > 1) query = query.Skip((page - 1) * limit);

        query = query.Take(limit);

        return query;
    }

    public IQueryable<T> GetAllByOrderPage(int page, int limit, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        query = orderBy(query);
        if (page > 1) query = query.Skip((page - 1) * limit);

        query = query.Take(limit);

        return query;
    }
}
