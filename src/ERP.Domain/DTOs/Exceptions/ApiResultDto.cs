
using System.Runtime.Serialization;

namespace ERP.Domain.DTOs.Exceptions;

[DataContract]
public class ApiResultDto<T>
{
    [DataMember(Name = "data")]
    public T Data { get; set; }

    [DataMember(Name = "error")]
    public ErrorDto Error { get; set; }

    [DataMember(Name = "meta")]
    public object Meta { get; set; }

    public ApiResultDto(T data)
    {
        Data = data;
    }

    public ApiResultDto()
    {
    }

    public static ApiResultDto<TData> FromData<TData>(TData data, object meta = null)
    {
        return new ApiResultDto<TData>
        {
            Data = data,
            Meta = meta
        };
    }

    public static ApiResultDto<object> FromError(ErrorDto error)
    {
        return new ApiResultDto<object>
        {
            Error = error
        };
    }
}
