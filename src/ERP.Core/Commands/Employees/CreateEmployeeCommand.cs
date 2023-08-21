using ERP.Domain.DTOs.Exceptions;
 

using FluentValidation;

using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Commands.Employees;

/// <summary>
/// Create employee view model
/// </summary>
public class CreateEmployeeCommand : IRequest<ResultDto<long>>
{
    [DisplayName("نام")]
    public string? FirstName { get; set; }
    [DisplayName("نام خانوادگی")]
    public string? LastName { get; set; }
    [DisplayName("کد پرسنلی")]
    public int EmpoloyeeNo { get; set; } = 0;
    [DisplayName("نام پدر")]
    public string? FatherName { get; set; }
    [DisplayName("کد ملی")]
    public string? NationalCode { get; set; }
    [DisplayName("شماره شناسنامه")]
    public string? IdentifyNo { get; set; }
    [DisplayName("تاریخ تولد")]
    public string? DateOfBirth { get; set; }
    [DisplayName("جنسیت")]
    public short Gender { get; set; }
    [DisplayName("تاریخ استخدام")]
    public string? HireDate { get; set; }
    [DisplayName("تاریخ ترک کار")]
    public string? LeaveDate { get; set; } = "";
    [DisplayName("شماره موبایل")]
    public string? MobileNo { get; set; }
    [DisplayName("مسیرعکس")]
    public string? ImaghePath { get; set; } = "";
}


/// <summary>
/// Check validation of employee input in create
/// </summary>
public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(50).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(3).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(50).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(3).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");

        RuleFor(v => v.EmpoloyeeNo).NotEqual(0).WithMessage("{PropertyName} را وارد نمایید.");

        RuleFor(v => v.FatherName)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(50).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(3).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");
              
        RuleFor(v => v.NationalCode)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(10).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(10).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");
                       
        RuleFor(v => v.IdentifyNo)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MinimumLength(1).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");

        RuleFor(v => v.DateOfBirth)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(10).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(10).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");
                          
        RuleFor(v => v.HireDate)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(10).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(10).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");
                                  
        RuleFor(v => v.MobileNo)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.");
        
    }

}