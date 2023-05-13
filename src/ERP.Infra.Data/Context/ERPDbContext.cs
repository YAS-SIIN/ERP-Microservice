using ERP.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Context;

public class ERPDbContext : DbContext
{
    public ERPDbContext(DbContextOptions options) : base(options)
    {
    }
    #region Employe    
    public DbSet<EMPEmployee> EMPEmployees { get; set; }
    #endregion
               
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.Name == "Status"));
                 
        #region Employe 
        new EMPEmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<EMPEmployee>());
        #endregion
        modelBuilder.Entity<EMPEmployee>().Property(x => x.Id).UseHiLo("EMPEmployee_Hilo");

        //foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    mutableEntityType.SetQueryFilter(filterExpr);
        //}
        //foreach (var property in mutableProperties)
        //    property. = "varchar(100)";

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ERPDbContext).Assembly); base.OnModelCreating(modelBuilder);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}