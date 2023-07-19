﻿
namespace ERP.Domain.DTOs.Employee;

public class GetAllEmployeeResponse
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int EmpoloyeeNo { get; set; } = 0;
    public string? FatherName { get; set; }
    public string? NationalCode { get; set; }
    public string? IdentifyNo { get; set; }
    public string? DateOfBirth { get; set; }
    public short Gender { get; set; }
    public string? HireDate { get; set; }
    public string? LeaveDate { get; set; } = "";
    public string? MobileNo { get; set; }
    public string? ImaghePath { get; set; } = "";
}
