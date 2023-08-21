
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Common.Enums;

public enum EnumResponseErrors : int
{
    [Display(Name = "اطلاعاتی یافت نشد.")]
    NotFound = 100,

    [Display(Name = "عملیات با موفقیت انجام شد.")]
    Done = 101,

    [Display(Name = "فرمت فایل مجاز نمی باشد.")]
    FileFormat = 103,

    [Display(Name = "فایل انتخاب نشده است.")]
    NotFoundFile = 104,

    [Display(Name = "شما به این عملیات دسترسی ندارید.")]
    NotAccess = 105,

    [Display(Name = "شما وارد سیستم شده اید.")]
    LoginedUser = 106,

    [Display(Name = "اطلاعات مورد نظر قابل حذف نمی باشد.")]
    NotDelete = 107,

    [Display(Name = "اطلاعاتی با موفقیت ثبت شد.")]
    Success = 200,
     
    [Display(Name = "خطایی در انجام عملیات رخ داده است.")]
    Error = 400,
     
}
