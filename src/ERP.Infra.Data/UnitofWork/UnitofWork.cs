
using ERP.Domain.Interfaces.Repositories;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.Context;
using ERP.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
namespace ERP.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ERPDbContext _context;
    private bool disposed = false;

    public UnitOfWork(ERPDbContext context)
    {

      // Database.SetInitializer<MyDataBase>(null);
        if (context == null)
            throw new ArgumentException("context is null!");
        _context = context;
    }

    public IGenericRepository<T> GetRepository<T>() where T : class
    {
        return new GenericRepository<T>(_context);
    }

   
    public void SaveChanges()
    {
        try
        {
            _context.SaveChanges();
        }
        catch
        {
        }
    }

    public async void SaveChangesAsync()
    {
        try
        {
            _context.SaveChangesAsync();
        }
        catch
        {
        }
    }

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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
