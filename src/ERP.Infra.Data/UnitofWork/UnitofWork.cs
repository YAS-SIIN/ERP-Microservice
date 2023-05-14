
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.Repositories;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.CoreContext;
using ERP.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
namespace ERP.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CoreDBContextInjection _context;
    private bool disposed = false;
    private readonly EnumDBContextType _dbContextType;

    public UnitOfWork(CoreDBContextInjection context, EnumDBContextType dbContextType)
    {

      // Database.SetInitializer<MyDataBase>(null);
        if (context == null)
            throw new ArgumentException("DB context is null!");
        _context = context;
        _dbContextType = dbContextType;
    }

    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        return new GenericRepository<T>(_context, _dbContextType);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                switch (_dbContextType)
                {
                    case EnumDBContextType.MAIN_ERPDBContext:
                        _context._main_ERPDBContext.Dispose();
                        break;
                    case EnumDBContextType.READ_ERPDBContext:
                         _context._read_ERPDBContext.Dispose();
                        break;
                    case EnumDBContextType.WRITE_ERPDBContext:
                        _context._write_ERPDBContext.Dispose();
                        break;
                }                                         
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


}
