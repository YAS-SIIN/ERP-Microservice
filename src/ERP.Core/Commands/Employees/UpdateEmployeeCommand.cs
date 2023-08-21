
using ERP.Domain.DTOs.Employee;
using ERP.Domain.DTOs.Exceptions;

using FluentValidation;
  

using MediatR;
 

using System.ComponentModel;

namespace ERP.Core.Commands.Employees;

/// <summary>
/// Update employee view model
/// </summary>
public class UpdateEmployeeCommand : IRequest<ResultDto<GetEmployeeResponse>>
{
    /// <summary>
    /// Employee Id
    /// </summary> 
    [DisplayName("شناسه یکتای پرسنل")]
    public int Id { get; set; }
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
    [DisplayName("شماره موبایل")]
    public string? MobileNo { get; set; }
    [DisplayName("مسیرعکس")]
    public string? ImaghePath { get; set; } = "";
}

/// <summary>
/// Check validation of employee input in update
/// </summary>
public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {

        RuleFor(v => v.FirstName)
           .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
           .MaximumLength(50).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
           .MinimumLength(3).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("{PropertyName} را وارد نمایید.")
            .MaximumLength(50).WithMessage("{PropertyName} نباید بیشتر از {MaxLength} کاراکتر باشد.")
            .MinimumLength(3).WithMessage("{PropertyName} حداقل {MinLength} کاراکتر باشد.");

        RuleFor(v => v.EmpoloyeeNo).Equal(0).WithMessage("{PropertyName} را وارد نمایید.");

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