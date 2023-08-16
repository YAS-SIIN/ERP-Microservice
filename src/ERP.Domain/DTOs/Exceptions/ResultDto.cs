 
using System.Text.Json.Serialization;

namespace ERP.Domain.DTOs.Exceptions;


public class ResultDto<T>
{
    public T? Data { get; set; }

    public int StatusCode { get; set; }

    public static ResultDto<T> ReturnData(int statusCode, T data)
    {
        return new ResultDto<T> { Data = data, StatusCode = statusCode };
    }

    public static ResultDto<T> ReturnData(int statusCode)
    {
        return new ResultDto<T> { StatusCode = statusCode };
    }
      
}