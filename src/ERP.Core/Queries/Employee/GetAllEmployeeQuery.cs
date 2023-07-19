

using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Queries.Employee;

public class GetAllEmployeeQuery : IRequest<Result<IList<GetAllEmployeeResponse>>>
{
}
