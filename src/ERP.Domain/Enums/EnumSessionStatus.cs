﻿
using System.ComponentModel.DataAnnotations;

namespace ERP.Common.Enums;

public enum EnumSessionStatus
{

    [Display(Name = "Logout")]
    Logout = 0,

    [Display(Name = "Login")]
    Login = 1,
}