using Azure;

using ERP.Domain.DTOs.Exceptions;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;      
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public IActionResult OkReult<T>(Result<T> response)
    {
        return new ObjectResult(response);
    }
    public IActionResult OkData<TData>(TData data, object meta = null)
    {
        return Ok(ApiResultDto<TData>.FromData(data, meta));
    }
}
