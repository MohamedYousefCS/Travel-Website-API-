﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travel_Website_System_API.Models;

[Table("BookingPackage")]
public partial class BookingPackage
{
    [Key]
    public int BookingPackageId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Data { get; set; }

    public int? quantity { get; set; }

    public int? clientId { get; set; }

    public int? packageId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? allowingTime { get; set; }

    [InverseProperty("BookingPackage")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("clientId")]
    [InverseProperty("BookingPackages")]
    public virtual Client client { get; set; }

    [ForeignKey("packageId")]
    [InverseProperty("BookingPackages")]
    public virtual Package package { get; set; }
}