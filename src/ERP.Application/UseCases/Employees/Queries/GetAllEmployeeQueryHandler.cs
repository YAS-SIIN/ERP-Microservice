


using ERP.Core.Queries.Employees;
using ERP.Domain.DTOs.Employee;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using ERP.Domain.Common.Enums;

using MediatR;
using ERP.Presentation.Shared.Extensions;
using ERP.Domain.DTOs;

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
        IList<GetEmployeeResponse> resData = Enumerable.Empty<GetEmployeeResponse>().ToList();
        var response = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(Domain.Enums.EnumDBContextType.READ_ERPDBContext).GetAllAsync(cancellationToken);


        //     return ResultDto<IList<GetEmployeeResponse>>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName());
 
        resData = Mapper<GetEmployeeResponse, Domain.Entities.ERP.Employees.Employee>.MapList(response.ToList());

        return ResultDto<IList<GetEmployeeResponse>>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName());
    }

}