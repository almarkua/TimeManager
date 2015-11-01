using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimeManager.Models
{
    public class User:IdentityUser
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string UserImage { get; set; }
        public string AboutMe { get; set; }

        public virtual IList<Category> Categories { get; set; }
        public IList<UserRole> UserRoles { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string userName):this()
        {
            UserName = userName;
        }

        public void Initialize()
        {
            Categories = new List<Category>() {new Category(){Description = "Заняття спорту", Name="Спорт"}};
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            return manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}