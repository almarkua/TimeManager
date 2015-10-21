using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimeManager.Models
{
    public class UserRole:IdentityUserRole
    {
        public Role Role { get; set; }
    }
}