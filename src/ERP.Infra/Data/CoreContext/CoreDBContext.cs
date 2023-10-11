using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ERP.Infra.Data.CoreContext;

public class MAIN_ERPDBContext : ERPDbContext
{
    public MAIN_ERPDBContext(DbContextOptions<MAIN_ERPDBContext> options) : base(options)
    {
    }
    public MAIN_ERPDBContext()
    {
    }
}

public class READ_ERPDBContext : ERPDbContext
{
    public READ_ERPDBContext(DbContextOptions<READ_ERPDBContext> options) : base(options)
    {
    }
}

public class WRITE_ERPDBContext : ERPDbContext
{
    public WRITE_ERPDBContext(DbContextOptions<WRITE_ERPDBContext> options) : base(options)
    {
    }
}
