
using ERP.Domain.DTOs.Exceptions;

namespace ERP.Core.Interfaces;

public interface ICommandHandler<in T>  
{
    Result Handle(T command);
}