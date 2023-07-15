using ERP.Application.UseCases.Employees.Commands;
using ERP.Core.Commands.Employee;
using ERP.Domain.Interfaces.UnitOfWork;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseApiController
{
    private IMediator _mmediator;
    private readonly IUnitOfWork _unitOfWork;
    public EmployeeController(IMediator mmediator, IUnitOfWork unitOfWork)
    {
        _mmediator = mmediator;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Creates a New Employee.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        //CreateEmployeeCommandHandler test = new CreateEmployeeCommandHandler(_unitOfWork);
        //test.Handle(command, new CancellationToken());
        return Ok(await _mmediator.Send(command));
    }
}
