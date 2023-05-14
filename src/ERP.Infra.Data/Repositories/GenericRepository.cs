﻿

using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.CoreContext;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Infra.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly CoreDBContextInjection _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(CoreDBContextInjection context, EnumDBContextType dBContextType)
    {
        _context = context;
        switch (dBContextType)
        {
            case EnumDBContextType.MAIN_ERPDBContext:
                _dbSet = context._main_ERPDBContext.Set<T>();
                break;
            case EnumDBContextType.READ_ERPDBContext:
                _dbSet = context._read_ERPDBContext.Set<T>();
                break;
            case EnumDBContextType.WRITE_ERPDBContext:
                _dbSet = context._write_ERPDBContext.Set<T>();
                break;
            default:
                _dbSet = context._main_ERPDBContext.Set<T>();
                break;
        }
    }

    public bool ExistData()
    {
        return _dbSet.Any();
    }

    public bool ExistData(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).Any();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public T Get(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).SingleOrDefault();
    }

    public virtual IQueryable<T> FromSqlRaw(string strQuery, object[] parametrs)
    {

        return _dbSet.FromSqlRaw(strQuery, parametrs.ToArray());
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void AddRange(List<T> entityList)
    {
        _dbSet.AddRange(entityList);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context._write_ERPDBContext.Entry(entity).State = EntityState.Modified;
    }

    public virtual void UpdateRange(List<T> entity)
    {
        _dbSet.AttachRange(entity);
        _context._write_ERPDBContext.Entry(entity).State = EntityState.Modified;
    }


    public virtual void Delete(T entity)
    { 
        if (_context._write_ERPDBContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(List<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }


    //--------------
    #region Async Methods

    public async Task<bool> ExistDataAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }
    public async Task<bool> ExistDataAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).AnyAsync(cancellationToken);
    }

    public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var data = await _dbSet.ToListAsync(cancellationToken);
        return data.AsQueryable();
    }
    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var data = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        return data.AsQueryable();
    }

    public async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).SingleOrDefaultAsync(cancellationToken);
    }

    public async virtual Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async virtual Task AddRangeAsync(List<T> entityList, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entityList, cancellationToken);
    }

    #endregion
    /// <summary>
    /// Save and commit changes in database
    /// </summary>
    public void SaveChanges()
    {
        try
        {
            _context._write_ERPDBContext.SaveChanges();
        }
        catch
        {
        }
    }

    /// <summary>
    /// Save and commit changes in database using multithread
    /// </summary>
    public async void SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
           await _context._write_ERPDBContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
        }
    }

}
