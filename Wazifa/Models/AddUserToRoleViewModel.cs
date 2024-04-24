using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wazifa.Models
{
    public class AddUserToRoleViewModel
    {
        public UserRole UserRole { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}