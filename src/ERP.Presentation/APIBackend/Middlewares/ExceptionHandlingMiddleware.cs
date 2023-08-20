
using ERP.Domain.DTOs;
using ERP.Domain.DTOs.Exceptions;
using ERP.Presentation.Shared.Exceptions;

using System.Text.Json;

namespace ERP.Presentation.APIBackend.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            { 

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            ErrorException errorException = new ErrorException(httpContext.Response.StatusCode, "");
            var statusCode = httpContext.Response.StatusCode;
            IDictionary<string, string[]> errors = new Dictionary<string, string[]>();
            try
            {
                statusCode = GetStatusCode(exception);
            } catch (Exception) {}
            try
            {
                errors = GetErrors(exception);
            }
            catch (Exception) { }
            try
            {
                errorException = (ErrorException)exception;
            } catch (Exception) {}

            ErrorDto response = new ErrorDto
            {
                StatusCode = statusCode,
                ErrorDescription = errorException.ErrorDescription,
                ErrorDetail = errorException.Message,
                ErrorCode = errorException.ErrorCode,
                Errors = errors
            };
            var errorData = ResultDto<ErrorDto>.ReturnData(statusCode, response);

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorData));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            { 
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                ErrorException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

        private static IDictionary<string, string[]> GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
