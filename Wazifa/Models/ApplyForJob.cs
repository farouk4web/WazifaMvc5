using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wazifa.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "الرسالة")]
        public string Message { get; set; }

        [Required]
        [Display(Name = "تاريخ التقديم")]
        public DateTime ApplyDate { get; set; }


        [Required]
        [Display(Name = "عنوان الوظيفة")]
        public int JobId { get; set; }

        public virtual Job job { get; set; }

        [Required]
        [Display(Name = "المتقدم للوظيفة")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}