
using MediatR;
using ERP.Domain.Enums;
using ERP.Domain.Common.Enums;
using ERP.Domain.DTOs;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Core.Commands.Employees;
using ERP.Domain.DTOs.Employee;
using ERP.Presentation.Shared.Mapper;
using ERP.Presentation.Shared.Extensions;
using ERP.Infra.Messaging;
using System.Text.Json;
using ERP.Presentation.Shared.Exceptions;

namespace ERP.Application.UseCases.Employee.Commands;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResultDto<GetEmployeeResponse>>
{
    private readonly IUnitOfWork _uw;
    private readonly IBus _bus;
    public UpdateEmployeeCommandHandler(IUnitOfWork uw, IBus bus)
    {
        _uw = uw;
        _bus = bus;
    }

    public async Task<ResultDto<GetEmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).GetByIdAsync((object)request.Id, cancellationToken);

        if (inputData is null && inputData is not Domain.Entities.ERP.Employees.Employee) throw new NotFoundException(EnumResponseErrors.NotFound.GetDisplayName());
            //throw new ErrorException((int)EnumResponseErrors.NotFound, EnumResponseErrors.NotFound.GetDisplayName());

        inputData = Mapper<Domain.Entities.ERP.Employees.Employee, UpdateEmployeeCommand>.MappClasses(request);
         
        _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).Update(inputData, true);

        GetEmployeeResponse outputData = Mapper<GetEmployeeResponse, Domain.Entities.ERP.Employees.Employee>.MappClasses(inputData);

        _bus.Publish($"Update_Created : {JsonSerializer.Serialize(request)}");
        return ResultDto<GetEmployeeResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName()); 
    }
}
