﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class AgeCategory
{
    public int AgeCategoryId { get; set; }

    public string AgeCategoryName { get; set; }

    public int AgeCategoryMinAge { get; set; }

    public int AgeCategoryMaxAge { get; set; }

    public int MaxDailyCalories { get; set; }
}