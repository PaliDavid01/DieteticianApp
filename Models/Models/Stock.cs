﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int MaterialId { get; set; }

    public int? MinimumStock { get; set; }

    public int? MaximumStock { get; set; }

    public decimal? PreCalculationPrice { get; set; }

    public decimal? CurrentStock { get; set; }

    public decimal? OrderUnitPrice { get; set; }

    public decimal? MaximumOrderPrice { get; set; }

    public decimal? CountingUnitPrice { get; set; }

    public decimal? SalePrice { get; set; }
}