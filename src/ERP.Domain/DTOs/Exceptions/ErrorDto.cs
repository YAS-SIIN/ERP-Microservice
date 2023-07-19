using Microsoft.AspNetCore.Mvc;

using System.Runtime.Serialization;
 

namespace ERP.Domain.DTOs.Exceptions;

[DataContract]
public class ErrorDto : ActionResult
{
    [DataMember(Name = "error_code")]
    public string ErrorCode { get; set; }

    [DataMember(Name = "error_description")]
    public string ErrorDescription { get; set; }
}
