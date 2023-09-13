using ERP.Core.Commands.Employees;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using ERP.Domain.Common.Enums;
using MediatR;
using ERP.Presentation.Shared.Tools;
using ERP.Infra.Messaging;
using System.Text.Json;

namespace ERP.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<long>>
{
    private readonly IUnitOfWork _uw;
    private readonly IBus _bus;
    public CreateEmployeeCommandHandler(IUnitOfWork uw, IBus bus)
    {
        _uw = uw;
        _bus = bus;
    }

    public async Task<ResultDto<long>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.ERP.Employees.Employee inputData = Mapper<Domain.Entities.ERP.Employees.Employee, CreateEmployeeCommand>.MappClasses(request);

        await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).AddAsync(inputData, cancellationToken, true);

        _bus.Publish($"Employee_Created : {JsonSerializer.Serialize(request)}");
        return ResultDto<long>.ReturnData(inputData.Id, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success,EnumResponseErrors.Success.GetDisplayName());
    }
}
