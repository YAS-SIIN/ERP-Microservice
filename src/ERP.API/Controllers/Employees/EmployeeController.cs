using ERP.Application.UseCases.Employees.Commands;
using ERP.Core.Commands.Employee;
using ERP.Core.Queries.Employee;
using ERP.Domain.Interfaces.UnitOfWork;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseApiController
{
    /// <summary>
    /// Creates a New Employee.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    { 
        return OkData(await Mediator.Send(command));
    }

    /// <summary>
    /// Get All Employees.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllEmployeeQuery();
        return OkData(await Mediator.Send(query));
    }
}
