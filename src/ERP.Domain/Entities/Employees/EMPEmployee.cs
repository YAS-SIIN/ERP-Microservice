
using ERP.Common;
using ERP.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.ComponentModel.DataAnnotations;


namespace ERP.Domain.Entities.Employees;

public class EMPEmployee : BaseEntity<long>
{

    public string FirstName { get; set; }

    public string LastName { get; set; }
                  
    public int EmpoloyeeNo { get; set; } = 0;
                    
    public string FatherName { get; set; }

    public string NationalCode { get; set; }

    public string IdentifyNo { get; set; }
                 
    public string DateOfBirth { get; set; }
                  
    public short Gender { get; set; }
                     
    public string HireDate { get; set; }

    public string LeaveDate { get; set; } = "";
                                
    public string MobileNo { get; set; }

    public string ImaghePath { get; set; } = "";
}

public class EMPEmployeeEntityTypeConfiguration : IEntityTypeConfiguration<EMPEmployee>
{
    public void Configure(EntityTypeBuilder<EMPEmployee> builder)
    {                                                     
        builder.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(b => b.LastName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.EmpoloyeeNo).IsRequired();
        builder.Property(b => b.FatherName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.NationalCode).IsRequired().HasMaxLength(10);
        builder.Property(b => b.IdentifyNo).IsRequired().HasMaxLength(10);
        builder.Property(b => b.DateOfBirth).IsRequired().HasMaxLength(10);
        builder.Property(b => b.Gender).IsRequired();
        builder.Property(b => b.HireDate).IsRequired().HasMaxLength(10);
        builder.Property(b => b.LeaveDate).IsRequired().HasMaxLength(10);
        builder.Property(b => b.MobileNo).IsRequired().HasMaxLength(11);
        builder.Property(b => b.ImaghePath).HasMaxLength(200);
   
    }
}