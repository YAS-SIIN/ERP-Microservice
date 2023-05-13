using Microsoft.EntityFrameworkCore;


namespace ERP.Infra.Data.Context;

public class MAIN_ERPDBContext : ERPDbContext
{
    public MAIN_ERPDBContext(DbContextOptions options) : base(options)
    {
    }
}

public class READ_ERPDBContext : ERPDbContext
{
    public READ_ERPDBContext(DbContextOptions options) : base(options)
    {
    }
}
  
public class WRITE_ERPDBContext : ERPDbContext
{
    public WRITE_ERPDBContext(DbContextOptions options) : base(options)
    {
    }
}
