 
using ERP.Domain.DTOs.Exceptions;

using ERP.Domain.Interfaces.UnitOfWork; 

using MediatR;
using ERP.Core.Commands.Employees; 
using ERP.Domain.Common.Enums;
using ERP.Domain.Enums;

namespace ERP.Application.UseCases.Employee.Commands;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResultDto<int>>
{
    private readonly IUnitOfWork _uw;
    public DeleteEmployeeCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).GetByIdAsync(request.Id, cancellationToken);

        if (inputData is not Domain.Entities.ERP.Employees.Employee)
            throw new ErrorException(EnumResponses.NotFound, "اطلاعاتی یافت نشد.");

        _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).Delete(inputData, true);
         
        return ResultDto<int>.ReturnData(EnumResponses.Success, request.Id);
    }
}
