﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class OrderListView
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime? OrderStartDate { get; set; }

    public DateTime? OrderEndDate { get; set; }

    public bool? HasOrderWeekMenu { get; set; }
}