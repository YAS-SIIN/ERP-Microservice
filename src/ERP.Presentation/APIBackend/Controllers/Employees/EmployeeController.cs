 
using ERP.Core.Commands.Employees;
using ERP.Core.Queries.Employees;
using ERP.Domain.Interfaces.UnitOfWork;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.APIBackend.Controllers.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseApiController
{
    private IMediator _mmediator;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Get all Employee.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllEmployeeQuery();
        return OkData(await Mediator.Send(query));
    }

    /// <summary>
    /// Get Employee.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetEmployeeQuery query)
    {
        return OkData(await Mediator.Send(query));
    }

    /// <summary>
    /// Creates a new Employee.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        return OkData(await Mediator.Send(command));
    }

    /// <summary>
    /// Update Employee.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeCommand command)
    {
        return OkData(await Mediator.Send(command));
    }

    /// <summary>
    /// Delete Employee.
    /// </summary>
    /// <returns>Result</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeCommand command)
    {

        return OkData(await Mediator.Send(command));
    }
}
