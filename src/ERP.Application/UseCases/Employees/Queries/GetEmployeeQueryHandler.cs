
using ERP.Core.Queries.Employees;
using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using ERP.Domain.Common.Enums;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Application.UseCases.Customers.Queries;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, ResultDto<GetEmployeeResponse>>
{

    private readonly IUnitOfWork _uw;
    public GetEmployeeQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<GetEmployeeResponse>> Handle(GetEmployeeQuery request,
        CancellationToken cancellationToken)
    {

        var response = await _uw.GetRepository<Employee>(EnumDBContextType.READ_ERPDBContext).GetByIdAsync(request.Id, cancellationToken); 

        if (response is not Employee)
            throw new ErrorException(EnumResponses.NotFound, "اطلاعاتی یافت نشد.");

        GetEmployeeResponse resData = Mapper<GetEmployeeResponse, Employee>.MappClasses(response);

        return ResultDto<GetEmployeeResponse>.ReturnData(EnumResponses.Success, resData);
    }
 
}