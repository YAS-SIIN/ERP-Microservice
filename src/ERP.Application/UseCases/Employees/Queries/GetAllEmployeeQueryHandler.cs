﻿


using ERP.Core.Queries.Employee;
using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using MabnaDBTest.Common.Enums;

using MediatR;


namespace ERP.Application.Application.UseCases.Employees.Queries;

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, ResultDto<IList<GetEmployeeResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllEmployeeQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<IList<GetEmployeeResponse>>> Handle(GetAllEmployeeQuery request,
        CancellationToken cancellationToken)
    { 
        var response = await _uw.GetRepository<Employee>(Domain.Enums.EnumDBContextType.READ_ERPDBContext).GetAllAsync(cancellationToken); 
        var resData = Mapper<IList<GetEmployeeResponse>, IList<Employee>>.MappClasses(response.ToList());
        return ResultDto<IList<GetEmployeeResponse>>.ReturnData(EnumResponses.Success, resData);
    }
 
}