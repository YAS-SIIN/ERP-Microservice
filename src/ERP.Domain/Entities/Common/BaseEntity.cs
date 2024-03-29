﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Linq.Expressions;            
using System.ComponentModel.DataAnnotations;
using ERP.Domain.Enums;

namespace ERP.Domain.Entities.Common;

/// <summary>
/// Base Entity Class Which is base of the every entity. 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseEntity<TKey>
{
    [Key]
    public TKey? Id { get; set; }

    [Required]
    public EnumBaseStatus Status { get; set; }

    [Required]
    public DateTime CreateDateTime { get; set; }

    [Required]
    public DateTime UpdateDateTime { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
}

///// <summary>
///// Fulent Configuration for BaseEntity
///// </summary>
///// <typeparam name="TEntity"></typeparam>
///// <typeparam name="TKey"></typeparam>
//public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
//{
//    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
//    {
//        builder.Property(be => be.Status).IsRequired();            
//        builder.Property(be => be.CreateDateTime).IsRequired();
//        builder.Property(be => be.UpdateDateTime).IsRequired();
//        builder.Property(be => be.Description).HasMaxLength(250);

//        builder.HasQueryFilter(x=> x.Status != (short)BaseStatus.Deleted);

//    }
//}