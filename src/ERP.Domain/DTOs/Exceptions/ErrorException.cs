using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ERP.Domain.DTOs.Exceptions;

public class ErrorException : Exception
{
    [DataMember(Name = "error_code")]
    public int ErrorCode { get; set; }

    [DataMember(Name = "error_description")]
    public string ErrorDescription { get; set; }

    [DataMember(Name = "trace_id")]
    public string TraceId { get; set; }

    [DataMember(Name = "error_detail")]
    public string ErrorDetail { get; set; }

    public ErrorException(int errorCode, string errorDescription, string traceId = "", string errorDetail="")
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ErrorDetail = errorDetail;
        TraceId = traceId;
    }
}
