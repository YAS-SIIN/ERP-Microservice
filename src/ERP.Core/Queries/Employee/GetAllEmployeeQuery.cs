

using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
 
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Queries.Employee;

public class GetAllEmployeeQuery : IRequest<ResultDto<IList<GetEmployeeResponse>>>
{
}
