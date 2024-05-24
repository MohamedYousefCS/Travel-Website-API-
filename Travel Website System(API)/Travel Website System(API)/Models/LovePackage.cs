﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travel_Website_System_API.Models;

[PrimaryKey("clientId", "packageId")]
[Table("LovePackage")]
public partial class LovePackage
{
    [Key]
    public int clientId { get; set; }

    [Key]
    public int packageId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? date { get; set; }

    [ForeignKey("clientId")]
    [InverseProperty("LovePackages")]
    public virtual Client client { get; set; }

    [ForeignKey("packageId")]
    [InverseProperty("LovePackages")]
    public virtual Package package { get; set; }
}