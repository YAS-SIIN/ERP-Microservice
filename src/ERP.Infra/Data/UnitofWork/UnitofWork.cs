
using Dapper;

using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.CoreContext;
using ERP.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ERP.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CoreDBContextInjection _context;                   

    public UnitOfWork(CoreDBContextInjection context)
    { 
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
     
    /// <summary>
    /// Dapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbContextType"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Dapper with async
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbContextType"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
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

}
