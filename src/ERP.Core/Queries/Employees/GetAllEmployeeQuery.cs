

using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs;
 
using MediatR;
 

namespace ERP.Core.Queries.Employees;

/// <summary>
/// Get all employee view model
/// </summary>
public class GetAllEmployeeQuery : IRequest<ResultDto<IList<GetEmployeeResponse>>>
{
}
