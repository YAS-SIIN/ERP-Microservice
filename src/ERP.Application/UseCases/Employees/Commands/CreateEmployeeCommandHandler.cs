 
using ERP.Core.Commands.Employee;
using ERP.Domain.DTOs.Exceptions;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;

using MabnaDBTest.Common.Enums;

using MediatR;

namespace ERP.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<long>>
{
    private readonly IUnitOfWork _uw;
    public CreateEmployeeCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<long>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee inputData = Mapper<Employee, CreateEmployeeCommand>.MappClasses(request);
        await _uw.GetRepository<Employee>(EnumDBContextType.WRITE_ERPDBContext).AddAsync(inputData, cancellationToken, true);

        return ResultDto<long>.ReturnData(EnumResponses.Success, inputData.Id);
    }
}
