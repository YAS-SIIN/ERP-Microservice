using System.Collections.Generic;
using System.Linq;

using ERP.Domain.DTOs.Exceptions;

using FluentValidation;
using FluentValidation.Results;

namespace ERP.Core.Commands;

public abstract class CommandHandlerBase
{
    protected IEnumerable<string> Notifications;

    protected ValidationResult Validate<T, TValidator>(
        T command,
        TValidator validator)
        where TValidator : IValidator<T>
    {
        var validationResult = validator.Validate(command);
        Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        return validationResult;
    }

    public Result Return() => new Result (!Notifications.Any(), Notifications);
}