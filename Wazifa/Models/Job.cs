using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wazifa.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "المسمي الوظيفي")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "وصف الوظيفة")]
        public string Description { get; set; }

        [Display(Name = "صورة الوظيفة")]
        public string ImageSrc { get; set; }

        [Required]
        [Display(Name = "نوع الوظيفة")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Display(Name = "ناشر الوظيفة")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ApplyForJob> Applers { get; set; }
    }
}