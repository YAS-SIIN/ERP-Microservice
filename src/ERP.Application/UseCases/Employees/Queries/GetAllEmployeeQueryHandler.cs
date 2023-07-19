

using ERP.Common.Mapper;
using ERP.Core.Commands.Employee;
using ERP.Core.Queries.Employee;
using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Interfaces.UnitOfWork;
 

using MabnaDBTest.Common.Enums;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Application.UseCases.Employees.Queries;

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Result<IList<GetAllEmployeeResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllEmployeeQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<Result<IList<GetAllEmployeeResponse>>> Handle(GetAllEmployeeQuery request,
        CancellationToken cancellationToken)
    {

        var response = await _uw.GetRepository<Employee>(Domain.Enums.EnumDBContextType.READ_ERPDBContext).GetAllAsync(cancellationToken); 
        var resData = Mapper<IList<GetAllEmployeeResponse>, IList<Employee>>.MappClasses(response.ToList());
        return Result<IList<GetAllEmployeeResponse>>.Success(EnumResponses.Success, resData);
    }
 
}