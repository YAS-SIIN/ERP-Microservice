
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Enums;

public static class EnumResponses
{

    [Display(Name = "اطلاعاتی یافت نشد.")]
    public const int NotFound = 100;

    [Display(Name = "عملیات با موفقیت انجام شد.")]
    public const int Done = 101;

    [Display(Name = "خطایی در انجام عملیات رخ داده است.")]
    public const int Error = 102;
            
    [Display(Name = "فرمت فایل مجاز نمی باشد.")]
    public const int FileFormat = 103;

    [Display(Name = "فایل انتخاب نشده است.")]
    public const int NotFoundFile = 104;

    [Display(Name = "شما به این عملیات دسترسی ندارید.")]
    public const int NotAccess = 105;

    [Display(Name = "شما وارد سیستم شده اید.")]
    public const int LoginedUser = 106;

    [Display(Name = "اطلاعات مورد نظر قابل حذف نمی باشد.")]
    public const int NotDelete = 107;
                          
    [Display(Name = "اطلاعاتی با موفقیت ثبت شد.")]
    public const int Success = 200;

}
