﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int BaseMaterialId { get; set; }

    public decimal Quantity { get; set; }

    public int RecipeId { get; set; }
}