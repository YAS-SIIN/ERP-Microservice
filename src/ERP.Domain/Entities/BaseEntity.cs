using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Linq.Expressions;
using static ERP.Common.Enums.TypeEnum;

namespace ERP.Domain.Entities;

public interface IBaseEntity
{
    public short Status { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime UpdateDateTime { get; set; }

    public string? Description { get; set; }
}

/// <summary>
/// Base Entity Class Which is base of the every entity. 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseEntity<TKey> : IBaseEntity
{
    public TKey? Id { get; set; }

    public short Status { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime UpdateDateTime { get; set; }

    public string? Description { get; set; }
}

/// <summary>
/// Fulent Configuration for BaseEntity
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(be => be.Status).IsRequired();
        builder.Property(be => be.CreateDateTime).IsRequired();
        builder.Property(be => be.UpdateDateTime).IsRequired();
        builder.Property(be => be.Description).HasMaxLength(250);
                               
        builder.HasQueryFilter(x=> x.Status != (short)BaseStatus.Deleted);
   
    }
}