using MediatR;                      

namespace ERP.Application.Behaviors;

public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{

    public UnhandledExceptionBehavior()
    {
    }
         
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        } 
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            throw ex;
        }
    }
}
