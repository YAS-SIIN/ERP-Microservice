
using Dapper;

using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.CoreContext;
using ERP.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Data;

namespace ERP.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CoreDBContextInjection _context;
    //private bool disposed = false;                       

    public UnitOfWork(CoreDBContextInjection context)
    {

      // Database.SetInitializer<MyDataBase>(null);
        if (context == null)
            throw new ArgumentException("DB context is null!");
        _context = context;              
    }


    /// <summary>
    /// Generate Repository of Entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbContextType"></param>
    /// <returns></returns>
    public IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class
    {                                     
        return new GenericRepository<T>(_context, dbContextType);
    }

    public IEnumerable<T> SqlQueryView<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class
    {

        IDbConnection dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();

        switch (dbContextType)
        {
            case EnumDBContextType.MAIN_ERPDBContext:
                dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.READ_ERPDBContext:
                dbConnection = _context._read_ERPDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.WRITE_ERPDBContext:
                dbConnection = _context._write_ERPDBContext.Database.GetDbConnection();
                break;
            default:
                dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();
                break;
        }

        using (dbConnection)
        {
            return dbConnection.Query<T>(sql, parameters);
        }
    }

    public async Task<IEnumerable<T>> SqlQueryViewAsync<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class
    {
        IDbConnection dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();

        switch (dbContextType)
        {
            case EnumDBContextType.MAIN_ERPDBContext:
                dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.READ_ERPDBContext:
                dbConnection = _context._read_ERPDBContext.Database.GetDbConnection();
                break;
            case EnumDBContextType.WRITE_ERPDBContext:
                dbConnection = _context._write_ERPDBContext.Database.GetDbConnection();
                break;
            default:
                dbConnection = _context._main_ERPDBContext.Database.GetDbConnection();
                break;
        }

        using (dbConnection)
        {
            return await dbConnection.QueryAsync<T>(sql, parameters);
        }
    }


    //public virtual void Dispose(bool disposing)
    //{
    //    if (!this.disposed)
    //    {
    //        if (disposing)
    //        {
    //            switch (_dbContextType)
    //            {
    //                case EnumDBContextType.MAIN_ERPDBContext:
    //                    _context._main_ERPDBContext.Dispose();
    //                    break;
    //                case EnumDBContextType.READ_ERPDBContext:
    //                     _context._read_ERPDBContext.Dispose();
    //                    break;
    //                case EnumDBContextType.WRITE_ERPDBContext:
    //                    _context._write_ERPDBContext.Dispose();
    //                    break;
    //            }                                         
    //        }
    //    }
    //    this.disposed = true;
    //}

    //public void Dispose()
    //{
    //    Dispose(true);
    //    GC.SuppressFinalize(this);
    //}


}
