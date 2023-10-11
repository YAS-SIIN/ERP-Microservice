using ERP.Domain.Entities.ERP.Accounts;
using ERP.Domain.Entities.ERP.Employees;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Context;

public class ERPDbContext : DbContext
{
    public ERPDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public ERPDbContext()
    {
    }

    #region Employee    
    public DbSet<Employee> EMPEmployees { get; set; }
    #endregion

    #region Account    
    public DbSet<User> Users { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Employee 
        new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
        modelBuilder.Entity<Employee>().ToTable("Employee", schema: "EMP");
        #endregion

        #region User 
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        modelBuilder.Entity<User>().ToTable("User", schema: "Acc");
        #endregion

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