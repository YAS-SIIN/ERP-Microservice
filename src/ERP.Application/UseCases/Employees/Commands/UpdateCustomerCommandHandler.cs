
using MediatR;
using ERP.Domain.Enums;
using ERP.Domain.Common.Enums;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Core.Commands.Employees;
using ERP.Domain.DTOs.Employee;
using ERP.Presentation.Shared.Mapper;

namespace ERP.Application.UseCases.Employee.Commands;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResultDto<GetEmployeeResponse>>
{
    private readonly IUnitOfWork _uw;
    public UpdateEmployeeCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<GetEmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).GetByIdAsync((object)request.Id, cancellationToken);

        if (inputData is null && inputData is not Domain.Entities.ERP.Employees.Employee)
            throw new ErrorException(EnumResponses.NotFound, "Data not found.");
         
        inputData = Mapper<Domain.Entities.ERP.Employees.Employee, UpdateEmployeeCommand>.MappClasses(request);
         
        _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).Update(inputData, true);

        GetEmployeeResponse outputData = Mapper<GetEmployeeResponse, Domain.Entities.ERP.Employees.Employee>.MappClasses(inputData);

        return ResultDto<GetEmployeeResponse>.ReturnData(EnumResponses.Success, outputData);
    }
}
