using ERP.Core.Commands.Employees;
using ERP.Domain.DTOs;
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Presentation.Shared.Mapper;
using ERP.Domain.Common.Enums;
using MediatR;
using ERP.Presentation.Shared.Tools;
using ERP.Presentation.Shared.Extensions;
using ERP.Infra.Messaging;
using System.Text.Json; 

namespace ERP.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultDto<int>>
{
    private readonly IUnitOfWork _uw;
    private readonly IBus _bus;
    private readonly ISecurity _security;
    public CreateEmployeeCommandHandler(IUnitOfWork uw, IBus bus, ISecurity security)
    {
        _uw = uw;
        _bus = bus;
        _security = security;
    }

    public async Task<ResultDto<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.ERP.Employees.Employee inputData = Mapper<Domain.Entities.ERP.Employees.Employee, CreateEmployeeCommand>.MappClasses(request);
        inputData.EmployeeNo = Convert.ToInt32(_uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).GetMaxAsync(x=> x.EmployeeNo, cancellationToken)) + 1;

        inputData.EmployeeNo = inputData.EmployeeNo == 0 || inputData.EmployeeNo == 1 ? 10001 : inputData.EmployeeNo;
        inputData.Status = (short)EnumBaseStatus.Deactive;

        Domain.Entities.ERP.Accounts.User user = new()
        {
            FirstName = inputData.FirstName,
            LastName = inputData.LastName,
            UserName = inputData.EmployeeNo.ToString(),
            MobileNo = inputData.MobileNo,
            PassWord = _security.HashPassword(inputData.NationalCode),
            Status = (short)EnumBaseStatus.Deactive,
            CreateDateTime = DateTime.Now
        };

        await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).AddAsync(inputData, cancellationToken, false);
        await _uw.GetRepository<Domain.Entities.ERP.Employees.Employee>(EnumDBContextType.WRITE_ERPDBContext).AddAsync(inputData, cancellationToken, false);


        _bus.Publish($"Employee_Created : {JsonSerializer.Serialize(request)}");
        return ResultDto<int>.ReturnData(inputData.EmployeeNo, (int)EnumResponseStatus.OK, (int)EnumResponseErrors.Success, EnumResponseErrors.Success.GetDisplayName());
    }
}
