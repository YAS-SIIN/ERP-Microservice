
using ERP.Domain.DTOs.Exceptions;

using FluentValidation;

using MediatR;

using System.ComponentModel;

namespace ERP.Core.Commands.Employees;

/// <summary>
/// Delete employee view model
/// </summary>
public class DeleteEmployeeCommand : IRequest<ResultDto<long>>
{
    /// <summary>
    /// Employee Id
    /// </summary> 
    [DisplayName("شناسه یکتای پرسنل")]
    public long Id { get; set; }
     
}


/// <summary>
/// Check validation of employee input in delete
/// </summary>
public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(v => v.Id).NotNull().WithMessage("{PropertyName} را وارد نمایید.");
             
    }

}