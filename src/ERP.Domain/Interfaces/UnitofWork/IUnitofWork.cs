
using ERP.Domain.Interfaces.Repositories;

using System;
                                    
namespace ERP.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> GetRepository<T>() where T : class;
                                                                 
    void SaveChanges();  
    void SaveChangesAsync();

}
