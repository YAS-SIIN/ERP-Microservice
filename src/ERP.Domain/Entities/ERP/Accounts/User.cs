using ERP.Domain;
using ERP.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ERP.Domain.Entities.ERP.Accounts;

public class User : BaseEntity<int>
{ 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNo { get; set; }
    public string UserName { get; set; }
    public string PassWord { get; set; } 
    public string ImagePath { get; set; } = "";
}

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(b => b.LastName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.MobileNo).IsRequired().HasMaxLength(11);
        builder.Property(b => b.UserName).IsRequired().HasMaxLength(100);
        builder.Property(b => b.PassWord).IsRequired().HasMaxLength(200);
        builder.Property(b => b.ImagePath).HasMaxLength(200);
    }
}