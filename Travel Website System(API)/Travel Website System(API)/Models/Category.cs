﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travel_Website_System_API.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int categoryId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; }

    [InverseProperty("category")]
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}