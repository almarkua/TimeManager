using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeManager.Models;

namespace TimeManager.Context
{
    public class MainContext : IdentityDbContext<User>
    {
        public IList<PublicCategory> PublicCategories { get; set; }

        public MainContext() : base("DefaultConnection")
        {

        }

        public static MainContext Create()
        {
            return new MainContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("ModelBuilder is NULL");
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            modelBuilder.Entity<Role>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
            modelBuilder.Entity<User>().HasMany<UserRole>((User u) => u.UserRoles);
            modelBuilder.Entity<UserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
            modelBuilder.Entity<User>()
                .HasMany(user => user.PublicCategories)
                .WithMany(category => category.Users)
                .Map(u => u.MapLeftKey("UserId").MapRightKey("CategoryId").ToTable("UsersPublicCategories"));
        }

        public bool CreateRole(RoleManager<Role> roleManager, string name, string description = "")
        {
            var res = roleManager.Create(new Role(name, description));
            return res.Succeeded;
        }

        public bool RoleExists(RoleManager<Role> roleManager, string name)
        {
            return roleManager.RoleExists(name);
        }

        public bool AddUserToRole(UserManager<User> userManager, User user, string roleName)
        {
            var res = userManager.AddToRole(user.Id, roleName);
            return res.Succeeded;
        }

        public void ClearUserRoles(UserManager<User> userManager, string userId)
        {
            var user = userManager.FindById(userId);
            var currentRoles = new List<UserRole>();

            currentRoles.AddRange(user.UserRoles);
            foreach (UserRole role in currentRoles)
            {
                userManager.RemoveFromRole(userId, role.Role.Name);
            }
        }

        public void RemoveFromRole(UserManager<User> userManager, string userId, string roleName)
        {
            userManager.RemoveFromRole(userId, roleName);
        }

        public void DeleteRole(UserManager<User> userManager, string roleId)
        {
            var roleUsers = Users.Where(u => u.UserRoles.Any(r => r.RoleId == roleId));
            var role = Roles.Find(roleId);

            foreach (var user in roleUsers)
            {
                this.RemoveFromRole(userManager, user.Id, role.Name);
            }
            Roles.Remove(role);
            SaveChanges();
        }

        
    }
}