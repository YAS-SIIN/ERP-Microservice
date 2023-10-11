

using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs;

using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Queries.Employees;

/// <summary>
/// Get employee view model
/// </summary>
public class GetEmployeeQuery : IRequest<ResultDto<GetEmployeeResponse>>
{
    /// <summary>
    /// Employee Id
    /// </summary>
    [DisplayName("شناسه یکتای پرسنل")]
    public int Id { get; set; }
}
