using ERP.Domain.Entities.ERP.Employees;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Context;

public class ERPDbContext : DbContext
{
    public ERPDbContext(DbContextOptions options) : base(options)
    {
    }
    #region Employee    
    public DbSet<Employee> EMPEmployees { get; set; }
    #endregion
               
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.Name == "Status"));
                 
        #region Employee 
        new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
        #endregion
        modelBuilder.Entity<Employee>().ToTable("Employee", schema: "EMP").Property(x => x.Id).UseHiLo("EMPEmployee_Hilo");
       
        //foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    mutableEntityType.SetQueryFilter(filterExpr);
        //}
        //foreach (var property in mutableProperties)
        //    property. = "varchar(100)";

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ERPDbContext).Assembly); base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
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

        return base.SaveChanges();
    }       

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
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