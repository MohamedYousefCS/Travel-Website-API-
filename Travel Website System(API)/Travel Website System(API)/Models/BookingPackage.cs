﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travel_Website_System_API.Models
{
    public class BookingPackage
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? quantity { get; set; }
        public DateTime? allowingTime { get; set; }

        public virtual Payment Payment { get; set; }

        [ForeignKey("client")]
        public string? clientId { get; set; }
        public virtual Client client { get; set; }

        [ForeignKey("package")]
        public int? packageId { get; set; }
        public virtual Package package { get; set; }
        public bool IsDeleted { get; set; }

    }
}