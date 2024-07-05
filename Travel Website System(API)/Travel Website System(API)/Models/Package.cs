﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Travel_Website_System_API_.Models;

namespace Travel_Website_System_API.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? QuantityAvailable { get; set; }
        public decimal? Price { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime? startDate { get; set; }
        public int? Duration { get; set; }
        public DateTime? EndDate { get; set; }
        public PackageLocationEnum ?FirstLocation { get; set; }// dropdownlist
        public PackageLocationEnum ?SecondLocation { get; set; }//dropdownlist

        private int? firstLocationDuration;// fileld
        public int? FirstLocationDuration// property
        {
            get => firstLocationDuration;
            set
            {
                if (value > Duration)
                {
                    throw new ArgumentException("FirstLocationDuration must be less than or equal to Duration.");
                }
                firstLocationDuration = value;
            }
        }
        public int? SecondLocationDuration { get; set; }// fixed : duration - FirstLocationDuration

        public int ?BookingTimeAllowed { get; set; }

        public virtual ICollection<BookingPackage> BookingPackages { get; set; } = new HashSet<BookingPackage>();
        public virtual ICollection<LovePackage> LovePackages { get; set; } = new HashSet<LovePackage>();

        [ForeignKey("admin")]
        public string? adminId { get; set; }
        public virtual Admin admin { get; set; }

        //[ForeignKey("packageId")]
        //[InverseProperty("packages")]
       // public virtual ICollection<Service> Services { get; set; } = new List<Service>();

        public virtual ICollection<PackageService> PackageServices { get; set; } = new HashSet<PackageService>();

    }
}