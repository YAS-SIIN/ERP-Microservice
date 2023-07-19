using System.Text.Json.Serialization;

namespace ERP.Domain.DTOs.Exceptions;


public class ResultDto<T>
{
    public T? Data { get; set; }

    [JsonIgnore] public int StatusCode { get; set; }

    public List<ErrorDto> Errors { get; set; }

    public static ResultDto<T> Success(int statusCode, T data)
    {
        return new ResultDto<T> { Data = data, StatusCode = statusCode };
    }

    public static ResultDto<T> Success(int statusCode)
    {
        return new ResultDto<T> { StatusCode = statusCode };
    }

    public static ResultDto<T> Fail(int statusCode, List<ErrorDto> errors)
    {
        return new ResultDto<T> { StatusCode = statusCode, Errors = errors };
    }

    public static ResultDto<T> Fail(int statusCode, ErrorDto error)
    {
        return new ResultDto<T> { StatusCode = statusCode, Errors = new List<ErrorDto> { error } };
    }
}