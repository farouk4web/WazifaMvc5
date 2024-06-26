﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wazifa.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم النوع")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "وصف النوع")]
        public string Description { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}