


using ERP.Core.Queries.Employees;
using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using ERP.Domain.Common.Enums;

using MediatR;
using ERP.Presentation.Shared.Tools;

namespace ERP.Application.UseCases.Employees.Queries;

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
        var response = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(Domain.Enums.EnumDBContextType.READ_ERPDBContext).GetAllAsync(cancellationToken);
        var resData = Mapper<IList<GetEmployeeResponse>, IList<Domain.Entities.ERP.Employees.Employee>>.MappClasses(response.ToList());

        return ResultDto<IList<GetEmployeeResponse>>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName()); 
    }

}