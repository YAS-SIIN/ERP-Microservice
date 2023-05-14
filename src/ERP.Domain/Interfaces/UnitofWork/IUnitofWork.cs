
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;

using System;
                                    
namespace ERP.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>(EnumDBContextType dbContextType) where T : class;
   
}
