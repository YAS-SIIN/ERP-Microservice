 
using ERP.Domain.DTOs;

using ERP.Domain.Interfaces.UnitOfWork; 

using MediatR;
using ERP.Core.Commands.Employees; 
using ERP.Domain.Common.Enums;
using ERP.Domain.Enums;
using ERP.Presentation.Shared.Extensions;
using ERP.Infra.Messaging;
using System.Text.Json;
using ERP.Presentation.Shared.Exceptions;

namespace ERP.Application.UseCases.Employee.Commands;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResultDto<int>>
{
    
    private readonly IUnitOfWork _uw;
    private readonly IBus _bus;
    public DeleteEmployeeCommandHandler(IUnitOfWork uw, IBus bus)
    {
        _uw = uw;
        _bus = bus;
    }

    public async Task<ResultDto<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).GetByIdAsync(request.Id, cancellationToken);

        if (inputData is not Domain.Entities.ERP.Employees.Employee) throw new NotFoundException(EnumResponseErrors.NotFound.GetDisplayName());
            //throw new ErrorException((int)EnumResponseErrors.NotFound, EnumResponseErrors.NotFound.GetDisplayName());

        _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).Delete(inputData, true);
          
        _bus.Publish($"Delete_Created : {JsonSerializer.Serialize(request)}");
        return ResultDto<int>.ReturnData(inputData.Id, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName());
    }
}
