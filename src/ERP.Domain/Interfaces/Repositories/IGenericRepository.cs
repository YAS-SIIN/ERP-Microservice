﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{

    bool ExistData();
    bool ExistData(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(object id);
    T Get(Expression<Func<T, bool>> predicate);
    IQueryable<T> FromSqlRaw(string strQuery, object[] parametrs);
    void Add(T entity);
    void AddRange(List<T> entityList);
    void Update(T entity);
    void UpdateRange(List<T> entity);
    void Delete(T entity);
    void DeleteRange(List<T> entity);
    
    //--------

    Task<bool> ExistDataAsync(CancellationToken cancellationToken);
    Task<bool> ExistDataAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(object id, CancellationToken cancellationToken);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task AddRangeAsync(List<T> entityList, CancellationToken cancellationToken);
     

}
