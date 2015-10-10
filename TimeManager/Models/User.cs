using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimeManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserImage { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }

        public virtual IList<Category> PrivateCategories { get; set; }
        public virtual IList<PublicCategory> PublicCategories { get; set; }
    }
}