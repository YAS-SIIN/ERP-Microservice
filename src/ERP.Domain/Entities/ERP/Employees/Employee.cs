using ERP.Domain;
using ERP.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ERP.Domain.Entities.ERP.Employees;

public class Employee : BaseEntity<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int EmployeeNo { get; set; } = 0;
    public string FatherName { get; set; }
    public string NationalCode { get; set; }
    public string IdentifyNo { get; set; }
    public string DateOfBirth { get; set; }
    public short Gender { get; set; }
    public string HireDate { get; set; }
    public string LeaveDate { get; set; } = "";
    public string MobileNo { get; set; }
    public string ImagePath { get; set; } = "";
}

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(b => b.LastName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.EmployeeNo).IsRequired();
        builder.Property(b => b.FatherName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.NationalCode).IsRequired().HasMaxLength(10);
        builder.Property(b => b.IdentifyNo).IsRequired().HasMaxLength(10);
        builder.Property(b => b.DateOfBirth).IsRequired().HasMaxLength(10);
        builder.Property(b => b.Gender).IsRequired();
        builder.Property(b => b.HireDate).IsRequired().HasMaxLength(10);
        builder.Property(b => b.LeaveDate).IsRequired().HasMaxLength(10);
        builder.Property(b => b.MobileNo).IsRequired().HasMaxLength(11);
        builder.Property(b => b.ImagePath).HasMaxLength(200);

    }
}