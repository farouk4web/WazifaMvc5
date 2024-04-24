using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wazifa.Models
{
    public class Contact
    {
        [Required]
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "موضوع الرسالة")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "نص الرسالة")]
        [AllowHtml]
        public string Message { get; set; }
    }
}