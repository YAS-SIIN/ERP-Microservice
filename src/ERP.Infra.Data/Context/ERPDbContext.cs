using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

using ERP.Domain.Entities.Employees;

using Microsoft.EntityFrameworkCore;

namespace SampleLibrary.Infra.Data.Context
{
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
            var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            #region Employe 
            new EMPEmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<EMPEmployee>());
            #endregion
            //foreach (var property in mutableProperties)
            //    property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ERPDbContext).Assembly); base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                    continue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                    entry.Property("Updated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}