
using Dapper;

using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;
//using ERP.Infra.Data.CoreContext;
using Microsoft.EntityFrameworkCore;

using System;
                                    
namespace ERP.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    //CoreDBContextInjection GetDbConext();

    IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class;

    IEnumerable<T> SqlQueryView<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class;
 
     Task<IEnumerable<T>> SqlQueryViewAsync<T>(EnumDBContextType dbContextType, string sql, DynamicParameters parameters = null) where T : class;
}
