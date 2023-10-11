
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain.Enums;

 
    public enum EnumGender
    {

        [Display(Name = "مرد")]
        Male = 0,

        [Display(Name = "زن")]
        Female = 1,
    }     