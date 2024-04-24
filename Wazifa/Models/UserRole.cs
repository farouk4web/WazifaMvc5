using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wazifa.Models
{
    public class UserRole
    {
        [Required]
        [Display(Name="User")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}