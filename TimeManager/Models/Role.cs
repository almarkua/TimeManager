using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimeManager.Models
{
    public class Role:IdentityRole
    {
        public Role() : base() { }

        public Role(string name, string description):base(name)
        {
            Description = description;
        }
            
        public virtual string Description { get; set; }
    }
}