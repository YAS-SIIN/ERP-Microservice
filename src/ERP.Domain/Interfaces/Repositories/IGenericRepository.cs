using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{

    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(object id);
    T Get(Expression<Func<T, bool>> predicate);
    void Add(T entity, bool save = false);
    void AddRange(List<T> entityList, bool save = false);
    void Update(T entity, bool save = false);
    void UpdateRange(List<T> entity, bool save = false);
    void Delete(T entity, bool save = false);
    void DeleteRange(List<T> entity, bool save = false);
    
    bool ExistData();
    bool ExistData(Expression<Func<T, bool>> predicate);
    //--------

    Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(object id, CancellationToken cancellationToken);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken, bool save = false);
    Task AddRangeAsync(List<T> entityList, CancellationToken cancellationToken, bool save = false);
    Task<bool> ExistDataAsync(CancellationToken cancellationToken);
    Task<bool> ExistDataAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken);

}
