﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Travel_Website_System_API.Models
{
    public class Client
    {

        public virtual Chat Chat { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}


