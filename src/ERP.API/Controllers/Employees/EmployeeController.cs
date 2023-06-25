using ERP.Core.Commands.Employee;

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
        return Ok(await Mediator.Send(command));
    }
}
