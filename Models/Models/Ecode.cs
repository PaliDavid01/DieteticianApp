﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Ecode
{
    public int EcodeId { get; set; }

    public int MaterialId { get; set; }

    public string Ecode1 { get; set; }

    public string Description { get; set; }

    public virtual BaseMaterial Material { get; set; }
}