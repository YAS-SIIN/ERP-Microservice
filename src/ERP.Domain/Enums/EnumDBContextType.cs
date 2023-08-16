using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ERP.Domain.Enums;

public enum EnumDBContextType
{

    [Display(Name = "MAIN ERP DBContext")]
    MAIN_ERPDBContext = 0,

    [Display(Name = "READ ERP DBContext")]
    READ_ERPDBContext = 1, 

    [Display(Name = "WRITE ERP DBContext")]
    WRITE_ERPDBContext = 2,
}
