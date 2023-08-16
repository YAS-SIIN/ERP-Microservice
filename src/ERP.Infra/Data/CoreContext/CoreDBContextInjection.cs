using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infra.Data.CoreContext;

public class CoreDBContextInjection
{
    public MAIN_ERPDBContext _main_ERPDBContext { get; }
    public READ_ERPDBContext _read_ERPDBContext { get; }
    public WRITE_ERPDBContext _write_ERPDBContext { get; }
    public CoreDBContextInjection(MAIN_ERPDBContext main_ERPDBContext, READ_ERPDBContext read_ERPDBContext,
        WRITE_ERPDBContext write_ERPDBContext)
    {
        _main_ERPDBContext = main_ERPDBContext;
        _read_ERPDBContext = read_ERPDBContext;
        _write_ERPDBContext = write_ERPDBContext;
    }
}

