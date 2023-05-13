
using System.ComponentModel.DataAnnotations;

namespace ERP.Common.Enums;

 
    public enum EnumBaseStatus
    {

        [Display(Name = "Deactive")]
        Deactive = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Deleted")]
        Deleted = 3
    }     