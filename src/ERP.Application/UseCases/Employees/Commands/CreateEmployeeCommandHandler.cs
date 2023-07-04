using ERP.Common.Mapper;
using ERP.Core.Commands.Employee;
using ERP.Domain.Entities.ERP.Employees;
using ERP.Domain.Enums;
using ERP.Domain.Interfaces.UnitOfWork;

using MediatR;

namespace ERP.Application.UseCases.Employees.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, long>
    {
        private readonly IUnitOfWork _uw;
        public CreateEmployeeCommandHandler(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EMPEmployee inputData = Mapper<EMPEmployee, CreateEmployeeCommand>.CommandToEntity(request);
            await _uw.GetRepository<EMPEmployee>(EnumDBContextType.WRITE_ERPDBContext).AddAsync(inputData, cancellationToken);
            return inputData.Id;
        }
    }
}
