using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.DTOs;

public class ErrorDto
{
    public int ErrorCode { get; set; }

    public string ErrorDescription { get; set; }
}
